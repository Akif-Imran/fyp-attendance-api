using AttendanceApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    [HttpGet]
    public IActionResult Login([FromBody] LoginViewModel loginViewModel)
    {
      return Ok();
    }
  }
}