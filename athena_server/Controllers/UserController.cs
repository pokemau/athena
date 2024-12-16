using athena_server.Models.DTO;
using athena_server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<ApplicationUserDTO>> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        var userDTO = new ApplicationUserDTO
        {
            Id = user.Id,
            UserName = user.UserName
        };

        return Ok(userDTO);
    }

    [HttpGet]
    public async Task<ActionResult<List<ApplicationUserDTO>>> GetUsers()
    {
        var users = _userManager.Users.ToList(); 

        var usersDTO = users.Select(user => new ApplicationUserDTO
        {
            Id = user.Id,
            UserName = user.UserName
        }).ToList();

        return Ok(usersDTO);
    }
}
