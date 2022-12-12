using AttendanceApi.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly StudentService _studentService;

    public StudentController(StudentService service)
    {
      _studentService = service;
    }

    [HttpGet(template: "get-all-students/{className}")]
    public IActionResult GetStudents(string className)
    {
      var list = _studentService.GetStudentByClass(className);
      return Ok(list);
    }
  }
}