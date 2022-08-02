namespace AttendanceApi.Data.Models
{
  public class Employee:User
  {
    public string EmployeeId { get; set; }
    public string designation { get; set; }
  }
}
