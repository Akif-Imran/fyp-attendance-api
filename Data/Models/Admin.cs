﻿namespace AttendanceApi.Data.Models
{
  public class Admin
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AccessLevel AccessLevel { get; set; }
  }
}