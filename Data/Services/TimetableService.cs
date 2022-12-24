using AttendanceApi.Data.Models;
using AttendanceApi.Data.ViewModels.Timetable;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AttendanceApi.Data.Services
{
  public class TimetableService
  {
    private readonly AppDbContext _context;

    public TimetableService(AppDbContext context)
    {
      _context = context;
    }

    public EntityEntry<Timetable> AddTimetable(InsertTimetableViewModel tb)
    {
      var record = new Timetable(tb);
      var result =  _context.Timetable.Add(record);
      _context.SaveChanges();
      return result;
    }
  }
}
