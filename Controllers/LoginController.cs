using AttendanceApi.Data.Services;
using AttendanceApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
      _loginService = loginService;
    }

    [HttpPost(template: "authenticate-user")]
    public IActionResult Login([FromBody] LoginViewModel loginViewModel)
    {
      var details = _loginService.AuthenticateUser(loginViewModel);
      return Ok(details);
    }
  }
}