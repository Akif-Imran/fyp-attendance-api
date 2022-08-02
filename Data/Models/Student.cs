namespace AttendanceApi.Data.Models
{
  public class Student : User
  {
    public string Regno { get; set; }
    public int Semester { get; set; }
    public string Discipline { get; set; }
    public string Degree { get; set; }
    public string Section { get; set; }
  }
}