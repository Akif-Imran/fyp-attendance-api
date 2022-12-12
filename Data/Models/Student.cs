namespace AttendanceApi.Data.Models
{
  public class Student
  {
    public int Id { get; set; }
    public string Regno { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Semester { get; set; }
    public string Discipline { get; set; }
    public string Degree { get; set; }
    public string Section { get; set; }

    //a class has many students
    public int ClassId { get; set; }

    public Class Class { get; set; }

    //a student has one parent.
    public int ParentId { get; set; }
    public Parent Parent { get; set; }

    //a student has many feature sets
    public ICollection<FeatureSet> Features { get; set; }

    //a student has many attendances
    public ICollection<Attendance> Attendances { get; set; }
  }
}