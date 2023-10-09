using a1tentication.Models;
using a1tentication.Models.DTO.Response;
using a1tentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace a1tentication.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private AuthService _service;
    public AuthController(AuthService srv)
    {
        this._service = srv;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password)
    {
        try
        {
            UserResponseDTO u = await this._service.LogIn(email, password);
            return Ok(u);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost, Route("LoginByToken")]
    public async Task<ActionResult<UserResponseDTO>> LoginByToken([FromForm] Guid token)
    {
        try
        {
            UserResponseDTO u = await this._service.LogInByToken(token);
            return Ok(u);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{guid}")]
    public async Task<IActionResult> CheckToken(Guid guid)
    {
        try
        {
            bool isValid = await this._service.CheckToken(guid);
            if (isValid)
            {
                return Ok(isValid);
            }
            return Unauthorized();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}