using AttendanceApi.Data.Models;

namespace AttendanceApi.Data.ViewModels.Student
{
  public class StudentsWithImagesViewModel
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

    //a student has one parent.
    public int ParentId { get; set; }

    public string ImageURL { get; set; }

    //attendance status
    public string Status { get; set; } = "absent";

    public StudentsWithImagesViewModel(AttendanceApi.Data.Models.Student s, string imageURL)
    {
      this.Id = s.Id;
      this.Regno = s.Regno;
      this.FirstName = s.FirstName;
      this.LastName = s.LastName;
      this.Semester = s.Semester;
      this.Discipline = s.Discipline;
      this.Degree = s.Degree;
      this.Section = s.Section;
      this.ClassId = s.ClassId;
      this.ParentId = s.ParentId;
      this.ImageURL = imageURL;
    }
  }
}