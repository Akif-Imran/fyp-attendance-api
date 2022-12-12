using AttendanceApi.Data.Models;
namespace AttendanceApi.Data.Services
{
  public class UserService
  {
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
	 _context = context;
    }

    public List<User> GetAllUsers()
    {
	 return _context.User.ToList<User>();
    }
  }
}
