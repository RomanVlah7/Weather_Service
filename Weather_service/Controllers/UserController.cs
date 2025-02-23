using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Weather_service.Data.Configs.RabbitMQ_config;
using Weather_service.Models;
using Weather_service.Service;

namespace Weather_service.Controllers;
[ApiController]
[Route("api/user/weather_service")]
public class UserController: Controller
{
    public UserController(UserService userService)
    {
        this._userService = userService;
    }
    
    private readonly UserService _userService;
    private readonly RabbitMqService _rabbitMqService = new RabbitMqService();
    
    [HttpGet]
    [Route("get-all-users")]
    public async Task<List<AppUser>> GetUsersList()
    {
        return await _userService.GetAllUsersAsync();
    }

    [HttpGet]
    [Route("get-user-by-id")]
    public async Task<AppUser> GetUserByIdAsync(long userId)
    {
        return await _userService.GetUserByIdAsync(userId);
    }

    [HttpPost]
    [Route("add-new-user")]
    public async Task AddNewUserAsync(AppUser appUser)
    {
        await _userService.AddNewUserAsync(appUser);
        _rabbitMqService.SendMessage(RabbitMqTopics.UserTopic, "User was added");
    }
    
    [HttpPost]
    [Route("update-user")]
    public async Task UpdateUserAsync(AppUser appUser, [FromHeader]long userId)
    {
        await _userService.UpdateUserAsync(appUser, userId);
    }
}