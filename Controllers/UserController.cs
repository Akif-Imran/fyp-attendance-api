using System.Security.Claims;
using AttendanceApi.Data.Models;
using AttendanceApi.Data.Services;
using AttendanceApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    [ActionName("Login")]
    public IActionResult Login([FromBody] LoginViewModel login)
    {
      if (!_userService.IsValidLogin(login.Username, login.Password)) return Unauthorized();
      var user = _userService.GetUser(login.Username);
      //TODO - if user login is valid then there will never be a null result.
      if (user == null) return Unauthorized("Unable to process request.");
      return Ok(new
      {
        firstName = user.FirstName,
        lastName = user.LastName,
        username = user.Username,
        role = user.Role
      });
    }
  }
}