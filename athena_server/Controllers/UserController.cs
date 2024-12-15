using athena_server.Models.DTO;
using athena_server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET api/user/{userId}
    [HttpGet("{userId}")]
    public async Task<ActionResult<ApplicationUserDTO>> GetUser(string userId)
    {
        // Fetch the user from the database using the userId
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        // Create a DTO for the user
        var userDTO = new ApplicationUserDTO
        {
            Id = user.Id,
            UserName = user.UserName
            // Map other fields if necessary
        };

        return Ok(userDTO);
    }

    // GET api/user
    [HttpGet]
    public async Task<ActionResult<List<ApplicationUserDTO>>> GetUsers()
    {
        // Fetch all users from the database
        var users = _userManager.Users.ToList(); // Alternatively, you can use async version if needed

        // Map to a list of DTOs
        var usersDTO = users.Select(user => new ApplicationUserDTO
        {
            Id = user.Id,
            UserName = user.UserName
            // Map other fields if necessary
        }).ToList();

        return Ok(usersDTO);
    }
}
