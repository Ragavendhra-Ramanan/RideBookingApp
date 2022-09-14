using com.ridebookingapp.Models;
using com.ridebookingapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace UsertoreApi.Controllers;

[ApiController]
[Route("api")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService UserService) =>
        _userService = UserService;


    
    [HttpGet]
    [Route("/api/v1.0/rideapp/login")]
    public async Task<IActionResult> Get(string name)
    {
        var item = await _userService.GetAsync(name);
        if (item is null)
        {
            return Problem("User Not found");
        }
        return Ok(item);
    }

    [HttpPost]
    [Route("/api/v1.0/rideapp/register")]
    public async Task<IActionResult> Get(User newUser)
    {
        var item = await _userService.GetAsync(newUser.Email);
        if (item is not null)
        {
            return Problem("User already Present");
        }
        await _userService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);

    }

    [HttpGet("{name}")]
    [Route("/api/v1.0/rideapp/{name}/forget")]
    public async Task<IActionResult> Update(string name, string password)
    {
        var user = await _userService.GetAsync(name);

        if (user is null)
        {
            return Problem("User not found");
        }

        user.Password=password;

        await _userService.UpdateAsync(name, user);

        return Ok(user);
    }

    
    
}