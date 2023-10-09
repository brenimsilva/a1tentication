using a1tentication.Models;
using a1tentication.Models.DTO.Request;
using a1tentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace a1tentication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _service;

    public UserController(UserService srv)
    {
        this._service = srv;
    }

    [HttpGet("{guid}")]
    public async Task<IActionResult> GetUserByGuid(Guid guid)
    {
        try
        {
            var u = await _service.GetUserByGuid(guid);
            return Ok(u);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewUser(UserRequestDTO user)
    {
        try
        {
            var u = await _service.CreateNewUser(user);
            return StatusCode(201, u);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}