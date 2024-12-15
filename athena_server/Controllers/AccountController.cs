using athena_server.Models.DTO;
using athena_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (success, error, userId) = await _accountService.LoginAsync(loginDto);

            if (success)
            {
                return Ok(new { Message = "Login successful", UserId = userId });
            }
            else
            {
                return Unauthorized(new { Error = error });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (success, error) = await _accountService.RegisterAsync(registerDto);

            if (success)
            {
                return Ok(new { Message = "Registration successful" });
            }
            else
            {
                return BadRequest(new { Error = error });
            }
        }
    }


}
