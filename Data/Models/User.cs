namespace AttendanceApi.Data.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRoles Role { get; set; }
  }

  public enum UserRoles : byte
  {
    Admin,
    Teacher,
    Student,
    Parent,
  }
}