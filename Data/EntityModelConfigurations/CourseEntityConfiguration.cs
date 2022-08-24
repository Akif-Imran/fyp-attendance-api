using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.HasKey(c => c.CourseCode);

      builder.Property(c => c.CourseCode)
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

      builder.Property(c => c.CourseName)
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

      builder.Property(c => c.CreditHours)
        .HasColumnType("int")
        .IsRequired();
    }
  }
}