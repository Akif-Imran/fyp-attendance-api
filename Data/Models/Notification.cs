namespace AttendanceApi.Data.Models
{
  public class Notification
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }
    public bool IsRead { get; set; }
  }
}