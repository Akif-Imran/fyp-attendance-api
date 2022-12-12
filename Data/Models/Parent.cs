namespace AttendanceApi.Data.Models
{
  public class Parent
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Student> Children { get; set; }
  }
}