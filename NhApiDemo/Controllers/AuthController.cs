using IAM.Api;
using Microsoft.AspNetCore.Mvc;
using NhApiDemo.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly UserBO _repo;

    public AuthController(UserBO repo, JwtService jwtService)
    {
        _repo = repo;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var user = _repo.GetByUsernameAndPassword(model.Username, model.Password);

        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        var token = _jwtService.GenerateToken(user.Name);

        return Ok(new
        {
            token = token,
            message = "Login successful"
        });
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}