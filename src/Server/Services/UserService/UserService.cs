﻿using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Common.Exceptions;
using CrossplatformHW.Server.Common.Extensions;
using CrossplatformHW.Server.Data;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Shared.Pagination.Parameters;
using Microsoft.EntityFrameworkCore;

namespace CrossplatformHW.Server.Services.UserService;

public sealed class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<User>> GetUsersByParametersAsync(BaseParameters parameters)
    {
        return await _db.Users
            .SearchFor(parameters.Search)
            .OrderBy(user => user.Username)
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Id.Equals(id));
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _db.Users
            .FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public async Task CreateUserAsync(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        
        var user = await GetUserByIdAsync(id);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        _db.Users.Remove(user);
        
        await _db.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
    }
}