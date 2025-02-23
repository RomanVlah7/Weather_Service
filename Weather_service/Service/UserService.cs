using Microsoft.EntityFrameworkCore.ChangeTracking;
using Weather_service.Data;
using Weather_service.Models;
using Weather_service.Repository;

namespace Weather_service.Service;

public class UserService
{
    public UserService(UserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    private readonly UserRepository _userRepository;

    public async Task<List<AppUser>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(long userId)
    {
        return await _userRepository.GetUserByIdAsync(userId);
    }

    public async Task AddNewUserAsync(AppUser appUser)
    {
        await _userRepository.AddNewUserAsync(appUser);
    }

    public async Task UpdateUserAsync(AppUser appUser, long userId)
    {
        await _userRepository.UpdateUserAsync(appUser, userId);
    } 
}