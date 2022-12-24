﻿namespace AttendanceApi.Data.Models
{
  public class Teacher
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public ICollection<Lecture> Lectures { get; set; }
    public ICollection<Teaches> Teaches { get; set; }
    public ICollection<Timetable> Timetables { get; set; }
  }
}