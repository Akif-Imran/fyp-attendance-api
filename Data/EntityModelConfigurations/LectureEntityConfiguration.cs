using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class LectureEntityConfiguration : IEntityTypeConfiguration<Lecture>
  {
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(l => l.Id)
        .UseIdentityColumn(1, 1);

      builder.HasIndex(l => new { l.CourseCode, l.TeacherId, l.LectureSlotId })
        .IsUnique();

      builder.Property(l => l.HeldOnDate)
        .HasConversion(
          v => v.ToShortDateString(),
          v => DateOnly.Parse(v)
        ).HasColumnType("varchar")
        .IsRequired();

      //a course has many lectures.
      builder.HasOne(l => l.Course)
        .WithMany(c => c.Lectures)
        .HasForeignKey(l => l.CourseCode);

      //a slot has many lectures
      builder.HasOne(l => l.LectureSlot)
        .WithMany(ls => ls.Lectures)
        .HasForeignKey(l => l.LectureSlotId);

      //a teacher conducts many lectures
      builder.HasOne(l => l.Teacher)
        .WithMany(t => t.Lectures)
        .HasForeignKey(l => l.TeacherId);
    }
  }
}