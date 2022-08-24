using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class AttendanceEntityConfiguration : IEntityTypeConfiguration<Attendance>
  {
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
      builder.HasKey(a => new { a.LectureId, a.StudentId, a.AttendanceNo });

      builder.Property(a => a.Status)
        .HasConversion(
          v => v.ToString(),
          v => Enum.Parse<AttendanceStatus>(v));

      builder.Property(a => a.AttendanceTime)
        .HasConversion(
          v => v.ToString(),
          v => TimeOnly.Parse(v));

      builder.HasOne(a => a.Lecture)
        .WithMany(l => l.Attendances)
        .HasForeignKey(a => a.LectureId);

      builder.HasOne(a => a.Student)
        .WithMany(s => s.Attendances)
        .HasForeignKey(a => a.StudentId)
        .HasPrincipalKey(s => s.Regno);
    }
  }
}