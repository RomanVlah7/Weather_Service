using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Weather_service.Data;
using Weather_service.Models;

namespace Weather_service.Repository;

public class UserRepository
{
    private readonly WeatherServiceDbContext _dbCOntext;

    public UserRepository(WeatherServiceDbContext dbContext)
    {
        _dbCOntext = dbContext;
    }

    public async Task<List<AppUser>> GetAllUsersAsync()
    {
        return await _dbCOntext.AppUser.AsNoTracking()
            .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(long userId)
    {
        return await _dbCOntext.AppUser.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == userId)! ?? throw new InvalidOperationException();
    }

    public async Task AddNewUserAsync(AppUser appUser)
    {
        await _dbCOntext.AddAsync(appUser);
        await _dbCOntext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(AppUser appUser, long userId)
    {
        await _dbCOntext.AppUser.Where(u => u.UserId.Equals(userId)).
            ExecuteUpdateAsync( s => s
                .SetProperty(user => user.UserName, appUser.UserName)
                .SetProperty(user => user.UserPassword, appUser.UserPassword));
        
    }
}