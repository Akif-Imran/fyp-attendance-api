using AttendanceApi.Data.Services;
using AttendanceApi.Data.ViewModels.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TimetableController : ControllerBase
  {
    private readonly TimetableService _timetableService;

    public TimetableController(TimetableService timetableService)
    {
      _timetableService = timetableService;
    }

    [HttpPost(template: "add-timetable")]
    public IActionResult AddTimetable([FromBody]InsertTimetableViewModel timetable)
    {
      var result = _timetableService.AddTimetable(timetable);

      return Ok();
    }
  }
}
