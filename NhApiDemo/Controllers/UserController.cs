using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhApiDemo;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repo;

    public UserController(UserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repo.GetAll());
    }

    [HttpPost]
    public IActionResult Post(User user)
    {
        _repo.Add(user);
        return Ok("User added");
    }
}