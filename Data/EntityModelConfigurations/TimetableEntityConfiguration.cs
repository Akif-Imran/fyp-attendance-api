using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class TimetableEntityConfiguration:IEntityTypeConfiguration<Timetable>
  {
    public void Configure(EntityTypeBuilder<Timetable> builder)
    {
      builder.HasKey(t => t.Id);

      //generate identity(1,1)
      builder.Property(t => t.Id)
        .HasColumnOrder(1)
        .UseIdentityColumn(1, 1)
        .ValueGeneratedOnAdd();

      builder.Property(t => t.Course)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(t => t.Day)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(t => t.Venue)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(t => t.ClassName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(t => t.StartTime)
        .HasConversion(v =>v.ToShortTimeString(),
          v => TimeOnly.Parse(v))
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(t => t.EndTime)
        .HasConversion(v => v.ToShortTimeString(),
          v => TimeOnly.Parse(v))
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.HasOne(t => t.Teacher)
        .WithMany(t => t.Timetables)
        .HasForeignKey(t => t.TeacherId);

      // builder.HasOne(t => t.Class)
      //   .WithMany(c => c.Timetables)
      //   .HasForeignKey(t => t.ClassId)
      //   .HasConstraintName("FK_Timetable_Class_ClassId_Foreign_Key");

    }
  }
}
