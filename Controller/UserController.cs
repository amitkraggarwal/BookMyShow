using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult index()
    {
        return Ok("User Controller is working!");
    }

    [HttpPost("SignUp")]
    public CreateUserResponseDTO CreateUser([FromBody] CreateUserRequestDTO request)
    {
        try
        {
            var user = _userService.CreateUser(new User { name = request.name, email = request.email, password = request.password, 
            mobile=request.mobile, createdOn=DateTime.UtcNow, updatedOn=DateTime.UtcNow });
            return new CreateUserResponseDTO { userId = user.Id, status = ResponseStatus.Success };
        }
        catch (Exception ex)
        {
            return new CreateUserResponseDTO { userId = 0, status = ResponseStatus.Failure, message = ex.Message };
        }
    }

[HttpGet("Login")]
    public IActionResult GetUser (string emailId, string password)
    {
        var user = _userService.GetUserByEmail(emailId);
        if (user == null)
        {
            return NotFound();
        }
        else
        {
            string passwordHash = user.password;
            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            if (!isPasswordValid)
            {
                return Unauthorized("Invalid password");
            }
            return Ok(user);
        }
        
    }
}       