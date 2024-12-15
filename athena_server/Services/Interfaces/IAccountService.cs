using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface IAccountService
    {
        Task<(bool Success, string? Error)> LoginAsync(LoginDTO loginDto);
        Task<(bool Success, string? Error)> RegisterAsync(RegisterDTO registerDto);
    }
}
