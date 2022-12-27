using AttendanceApi.Data.Models;
using AttendanceApi.Data.ViewModels.Timetable;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Data.Services
{
  public class TeacherService
  {
    private readonly AppDbContext _context;

    public TeacherService(AppDbContext context)
    {
      _context = context;
    }

    public IList<ClassSessionByDayViewModel> GetTeacherTimetable(int id)
    {
      var result = new List<ClassSessionByDayViewModel>();

      var groups = _context.Timetable
        .Where(t => t.TeacherId == id)
        .AsEnumerable()
        .GroupBy(t => t.Day)
        .ToDictionary(
          key => key.Key,
          value => value
            .OrderBy(t => t.Slot)
            .ToList()
        );
      var days = new Dictionary<string, int>()
      {
        { "Sunday", 0 }, { "Monday", 1 }, { "Tuesday", 2 }, { "Wednesday", 3 }, { "Thursday", 4 }, { "Friday", 5 },
        { "Saturday", 6 }
      };
      foreach (var group in groups)
      {
        var daySession = new ClassSessionByDayViewModel
        {
          Day = group.Key,
          Sessions = new List<ClassSessionViewModel>(),
          WeekDay = days.GetValueOrDefault(group.Key)
        };

        if (days.ContainsKey(daySession.Day))
        {
          days.Remove(daySession.Day);
        }

        foreach (var timetable in group.Value)
        {
          daySession.Sessions.Add(new ClassSessionViewModel()
          {
            Class = timetable.ClassName,
            Venue = timetable.Venue,
            Subject = timetable.Course,
            Start = timetable.StartTime.ToShortTimeString(),
            Stop = timetable.EndTime.ToShortTimeString(),
            Slot = timetable.Slot,
          });
        }

        result.Add(daySession);
      }

      var missingRange = days
        .Select(day => new ClassSessionByDayViewModel()
          { Day = day.Key, WeekDay = day.Value, Sessions = new List<ClassSessionViewModel>() });

      result.AddRange(missingRange);
      result = result
        .OrderBy(t => t.WeekDay)
        .ToList();

      return result;
    }
  }
}