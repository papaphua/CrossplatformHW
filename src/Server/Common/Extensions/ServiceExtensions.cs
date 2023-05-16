using CrossplatformHW.Server.Auth.PermissionHandler;
using CrossplatformHW.Server.Common.Options.Setups;
using CrossplatformHW.Server.Common.Providers.LinkProvider;
using CrossplatformHW.Server.Common.Providers.PasswordProvider;
using CrossplatformHW.Server.Common.Providers.TokenProvider;
using CrossplatformHW.Server.Facades.AuthFacade;
using CrossplatformHW.Server.Facades.CategoryFacade;
using CrossplatformHW.Server.Facades.CommentFacade;
using CrossplatformHW.Server.Facades.ProductFacade;
using CrossplatformHW.Server.Facades.ProfileFacade;
using CrossplatformHW.Server.Facades.UserFacade;
using CrossplatformHW.Server.Services.CategoryService;
using CrossplatformHW.Server.Services.CommentService;
using CrossplatformHW.Server.Services.MailService;
using CrossplatformHW.Server.Services.PaymentService;
using CrossplatformHW.Server.Services.PermissionService;
using CrossplatformHW.Server.Services.ProductService;
using CrossplatformHW.Server.Services.SecurityService;
using CrossplatformHW.Server.Services.SessionService;
using CrossplatformHW.Server.Services.UserService;
using DotNetEnv;
using Microsoft.AspNetCore.Authorization;

namespace CrossplatformHW.Server.Common.Extensions;

public static class ServiceExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IPasswordProvider, PasswordProvider>();
        services.AddScoped<ILinkProvider, LinkProvider>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IPaymentService, PaymentService>();

        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IProfileFacade, ProfileFacade>();
        services.AddScoped<IAuthFacade, AuthFacade>();
    }

    public static void SetupOptions(this IServiceCollection services)
    {
        Env.Load();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<BearerOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<SecurityOptionsSetup>();
        services.ConfigureOptions<MailOptionsSetup>();
        services.ConfigureOptions<PasswordOptionsSetup>();
        services.ConfigureOptions<UrlOptionsSetup>();
        services.ConfigureOptions<PaymentOptionsSetup>();
    }

    public static void AddPermissionAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthPolicyProvider>();
    }
}