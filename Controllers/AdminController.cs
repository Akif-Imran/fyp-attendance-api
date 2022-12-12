using AttendanceApi.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly AdminService _adminService;

    public AdminController(AdminService adminService)
    {
	 _adminService = adminService;
    }

    [HttpGet(template:"get-all")]
    public IActionResult GetAllAdmins()
    {
	 var admins = _adminService.GetAllAdmins();
	 return Ok(admins);
    }
  }
}
