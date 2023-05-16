﻿using System.Security.Claims;
using AutoMapper;
using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Common.Exceptions;
using CrossplatformHW.Server.Common.Options;
using CrossplatformHW.Server.Common.Providers.LinkProvider;
using CrossplatformHW.Server.Common.Providers.PasswordProvider;
using CrossplatformHW.Server.Common.Providers.TokenProvider;
using CrossplatformHW.Server.Data;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Server.Services.MailService;
using CrossplatformHW.Server.Services.PaymentService;
using CrossplatformHW.Server.Services.SecurityService;
using CrossplatformHW.Server.Services.SessionService;
using CrossplatformHW.Server.Services.UserService;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CrossplatformHW.Server.Facades.AuthFacade;

public sealed class AuthFacade : IAuthFacade
{
    private readonly AppDbContext _db;
    private readonly ILinkProvider _linkProvider;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IPaymentService _paymentService;
    private readonly ISecurityService _securityService;
    private readonly ISessionService _sessionService;
    private readonly ITokenProvider _tokenProvider;
    private readonly UrlOptions _urlOptions;
    private readonly IUserService _userService;

    public AuthFacade(
        IUserService userService,
        IPasswordProvider passwordProvider,
        IMapper mapper,
        ITokenProvider tokenProvider,
        IPaymentService paymentService,
        ISessionService sessionService,
        ISecurityService securityService,
        IMailService mailService,
        IOptions<UrlOptions> urlOptions,
        ILinkProvider linkProvider, AppDbContext db)
    {
        _userService = userService;
        _passwordProvider = passwordProvider;
        _mapper = mapper;
        _tokenProvider = tokenProvider;
        _paymentService = paymentService;
        _sessionService = sessionService;
        _securityService = securityService;
        _mailService = mailService;
        _linkProvider = linkProvider;
        _db = db;
        _urlOptions = urlOptions.Value;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        var userByUsername = await _userService.GetUserByUsernameAsync(registerDto.Username);
        var userByEmail = await _userService.GetUserByEmailAsync(registerDto.Email);

        if (userByUsername is not null && userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAndEmailAlreadyExist(registerDto.Username, registerDto.Email));

        if (userByUsername is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAlreadyExist(registerDto.Username));

        if (userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.EmailAlreadyExist(registerDto.Email));

        if (!registerDto.Password.Equals(registerDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        User user;
        
        var transaction = await _db.Database.BeginTransactionAsync();
        const string savepoint = nameof(RegisterAsync);
        await transaction.CreateSavepointAsync(savepoint);

        try
        {
            user = _mapper.Map<User>(registerDto);
            user.PasswordHash = _passwordProvider.GetPasswordHash(registerDto.Password);
            
            if (!_db.Users.Any())
                user.RoleId = (int)Roles.Admin;
            else
                user.RoleId = (int)Roles.Customer;
            
            var customerId = await _paymentService.AddPaymentProfileAsync(user);
            user.CustomerId = customerId;

            await _userService.CreateUserAsync(user);
            
            await _securityService.CreateSecurityForUserAsync(user.Id);

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackToSavepointAsync(savepoint);
            
            throw;
        }
        
        await GetEmailConfirmationLinkAsync(user.Id);
    }

    public async Task<string> FindLoginInfoAsync(LoginDto loginDto)
    {
        var userByUsername = await _userService.GetUserByUsernameAsync(loginDto.Login);
        var userByEmail = await _userService.GetUserByEmailAsync(loginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailNotConfirmed(user.Email));

        if (!user.IsTfaEnabled) return _linkProvider.GenerateLoginLink(_urlOptions.DefaultLoginUrl, loginDto.Login);

        await _securityService.GenerateConfirmationCodeAsync(user.Id);
        await GetConfirmationCodeAsync(user.Id);
        return _linkProvider.GenerateLoginLink(_urlOptions.TwoAuthLoginUrl, loginDto.Login);
    }

    public async Task<AuthDto> DefaultLoginAsync(DefaultLoginDto defaultLoginDto)
    {
        var userByUsername = await _userService.GetUserByUsernameAsync(defaultLoginDto.Login);
        var userByEmail = await _userService.GetUserByEmailAsync(defaultLoginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.IsTfaEnabled)
            return new AuthDto
            {
                IsSucceeded = false,
                Url = _linkProvider.GenerateLoginLink(_urlOptions.TwoAuthLoginUrl, defaultLoginDto.Login),
                Tokens = null
            };

        if (!_passwordProvider.VerifyPassword(defaultLoginDto.Password, user.PasswordHash))
            throw new NotFoundException(ExceptionMessages.WrongPassword);

        if (!user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailNotConfirmed(user.Email));

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionService.CreateSessionAsync(user.Id, accessToken, refreshToken);

        return new AuthDto
        {
            IsSucceeded = true,
            Url = null,
            Tokens = new TokenDto(accessToken, refreshToken)
        };
    }

    public async Task<AuthDto> TwoAuthLoginAsync(TwoAuthLoginDto twoAuthLoginDto)
    {
        var userByUsername = await _userService.GetUserByUsernameAsync(twoAuthLoginDto.Login);
        var userByEmail = await _userService.GetUserByEmailAsync(twoAuthLoginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!user.IsTfaEnabled)
            return new AuthDto
            {
                IsSucceeded = false,
                Url = _linkProvider.GenerateLoginLink(_urlOptions.DefaultLoginUrl, twoAuthLoginDto.Login),
                Tokens = null
            };

        if (!_passwordProvider.VerifyPassword(twoAuthLoginDto.Password, user.PasswordHash))
            throw new NotFoundException(ExceptionMessages.WrongPassword);

        await _securityService.IsConfirmationCodeValidAsync(user.Id, twoAuthLoginDto.ConfirmationCode);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionService.CreateSessionAsync(user.Id, accessToken, refreshToken);

        await _securityService.RemoveConfirmationCodesAsync(user.Id);

        return new AuthDto
        {
            IsSucceeded = true,
            Url = null,
            Tokens = new TokenDto(accessToken, refreshToken)
        };
    }

    public async Task<AuthDto> RefreshAsync([FromBody] TokenDto tokenDto)
    {
        var principal = _tokenProvider.GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var userId = Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));

        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var session = await _sessionService.GetUserSessionAsync(userId);

        if (session is null) return new AuthDto { IsSucceeded = false };

        if (session.RefreshToken != tokenDto.RefreshToken ||
            session.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            _db.Sessions.Remove(session);
            await _db.SaveChangesAsync();
            return new AuthDto { IsSucceeded = false };
        }

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionService.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new AuthDto { IsSucceeded = true, Tokens = new TokenDto(accessToken, refreshToken) };
    }

    public async Task GetConfirmationCodeAsync(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var code = await _securityService.GenerateConfirmationCodeAsync(user.Id);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.ConfirmationCode(code));
    }

    public async Task GetNewEmailConfirmationCodesAsync(Guid userId, string email)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var code = await _securityService.GenerateNewEmailConfirmationCodeAsync(userId);

        await _mailService.SendEmailAsync(email, EmailMessages.ConfirmationCode(code));
    }

    public async Task GetEmailConfirmationLinkAsync(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailAlreadyConfirmed);

        var token = await _securityService.GenerateConfirmationTokenAsync(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.EmailConfirmationUrl, parameters);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.EmailConfirmation(link));
    }

    public async Task GetPasswordResetLinkAsync(EmailDto emailDto)
    {
        var user = await _userService.GetUserByEmailAsync(emailDto.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var token = await _securityService.GenerateConfirmationTokenAsync(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.PasswordResetUrl, parameters);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.PasswordReset(link));
    }

    public async Task<ResponseDto> ConfirmEmailAsync(ConfirmationParameters parameters)
    {
        var user = await _userService.GetUserByEmailAsync(parameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailAlreadyConfirmed);

        if (await _securityService.IsConfirmationTokenValidAsync(user.Id, parameters.Token))
        {
            user.IsEmailConfirmed = true;
            await _securityService.RemoveConfirmationTokenAsync(user.Id);
            await _db.SaveChangesAsync();
        }

        return new ResponseDto("Email confirmed");
    }

    public async Task ResetPasswordAsync(PasswordResetDto passwordResetDto)
    {
        var user = await _userService.GetUserByEmailAsync(passwordResetDto.ConfirmationParameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!passwordResetDto.NewPassword.Equals(passwordResetDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        if (await _securityService.IsConfirmationCodeValidAsync(user.Id, passwordResetDto.ConfirmationParameters.Token))
        {
            user.PasswordHash = _passwordProvider.GetPasswordHash(passwordResetDto.NewPassword);
            await _securityService.RemoveConfirmationCodesAsync(user.Id);
            await _db.SaveChangesAsync();
        }
    }
}