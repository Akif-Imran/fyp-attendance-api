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

    public TeacherController (TeacherService teacherService)
    {
	 _teacherService = teacherService;
    }

    [HttpGet(template: "get-teacher-info/{teacherId:int}")]
    public IActionResult GetTeacherInfo(int teacherId)
    {
      var teacherInfo = _teacherService.GetTeacherInfo(teacherId);
      if (teacherInfo is not null)
      {
        var result = new InfoWithTimetableViewModel(teacherInfo);
        return Ok(result);
      }
      return Ok(new {});
    }
  }
}
