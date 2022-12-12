using AttendanceApi.Data.Models;

namespace AttendanceApi.Data.Services
{
  public class StudentService
  {
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
      _context = context;
    }

    public List<Student> GetStudentByClass(string className)
    {
      return _context.Students
        .Where(s => s.Class.ClassIdentifier.Equals(className))
        .ToList();
    }
  }
}