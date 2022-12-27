using AttendanceApi.Data.Services;
using AttendanceApi.Data.ViewModels.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeacherController : ControllerBase
  {
    private readonly TeacherService _teacherService;

    public TeacherController(TeacherService teacherService)
    {
      _teacherService = teacherService;
    }

    [HttpGet(template: "get-teacher-timetable/{teacherId:int}")]
    public IActionResult GetTeacherInfo(int teacherId)
    {
      var teacherInfo = _teacherService.GetTeacherTimetable(teacherId);
      if (teacherInfo.Count != 0)
      {
        return Ok(teacherInfo);
      }

      return NotFound();
    }
  }
}