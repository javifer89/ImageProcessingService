using ImageProcessingService.Models;
using ImageProcessingService.Utils;
using Microsoft.AspNetCore.Identity;

namespace ImageProcessingService.Services
{
        private readonly UserManager<User> _userManager;
        private readonly JwtHelper _jwtHelper;
    public class AuthService(UserManager<User> userManager, JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _jwtHelper = jwtHelper;        
    }

    public async Task<string> RegisterAsync(string username, string password)
    {
        var user = new UserManager { username = username };
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new Exception("Registration failed");
        }
        return _jwtHelper.GenerateJwtToken(user);
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password)) {
            throw new Exception("Invalid login");
        }
        return _jwtHelper.GenerateJwtToken(user);
    }
}
