using AttendanceApi.Data.Models;

namespace AttendanceApi.Data.Services
{
  public class UserService
  {
    private AppDbContext _context;

    public UserService(AppDbContext context)
    {
      _context = context;
    }

    //TODO - add user needs to be of a particular type
    public void addUser(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public bool IsValidLogin(string? username, string? password)
    {
      if (username == null || password == null) return false;
      return _context.Users.Any(u => u.Username.Equals(username) && u.Password.Equals(password));
    }

    public User? GetUser(string? username)
    {
      var user = _context.Users.FirstOrDefault(u => u.Username.Equals(username));
      return user;
    }
  }
}