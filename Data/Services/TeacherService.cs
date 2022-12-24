using AttendanceApi.Data.Models;
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

    public Teacher? GetTeacherInfo(int id)
    {
      var result = _context.Teachers.Where(t => t.Id == id)
        .Include(t => t.Timetables)
        .SingleOrDefault();

      return result;
    }
  }
}
