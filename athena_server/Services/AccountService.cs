using athena_server.Models.DTO;
using athena_server.Models;
using Microsoft.AspNetCore.Identity;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class AccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<(bool Success, string? Error)> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return (false, "Invalid login attempt.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return (true, null);
            }
            else if (result.IsLockedOut)
            {
                return (false, "User account is locked.");
            }
            else
            {
                return (false, "Invalid login attempt.");
            }
        }

        public async Task<(bool Success, string? Error)> RegisterAsync(RegisterDTO registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return (false, "Passwords do not match.");
            }

            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return (true, null);
            }

            // Combine errors into a single message
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            return (false, errors);
        }

    }

}
