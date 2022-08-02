using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      builder.HasIndex(s => s.Regno)
        .IsUnique(true);

      //Regno configuration
      builder.Property(s => s.Regno)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      //semester configuration
      builder.Property(s => s.Semester)
        .HasColumnType("int")
        .IsRequired(true);

      //discipline configuration
      builder.Property(s => s.Discipline)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);

      //degree configuration
      builder.Property(s => s.Degree)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);


      //section configuration
      builder.Property(s => s.Section)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);

      //
    }
  }
}