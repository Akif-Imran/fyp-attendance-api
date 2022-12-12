using AttendanceApi.Data.Models;

namespace AttendanceApi.Data.Services
{
  public class AdminService
  {
    private readonly AppDbContext _context;

    public AdminService(AppDbContext context) {
	 _context = context;
    }

    public List<Admin> GetAllAdmins()
    {
	 return _context.Admins.ToList();
    }
  }
}
