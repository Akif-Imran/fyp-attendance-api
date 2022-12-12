using AttendanceApi.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
	 _userService = userService;
    }

    [HttpGet(template:"get-all")]
    public IActionResult GetAllUsers()
    {
	 var users =  _userService.GetAllUsers();
	 return Ok(users);
    }
  }
}
