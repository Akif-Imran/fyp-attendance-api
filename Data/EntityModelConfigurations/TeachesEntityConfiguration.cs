using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class TeachesEntityConfiguration : IEntityTypeConfiguration<Teaches>
  {
    public void Configure(EntityTypeBuilder<Teaches> builder)
    {
      builder.HasKey(ts => new { ts.ClassId, ts.TeacherId, ts.CourseCode, ts.Session });

      builder.Property(ts => ts.Session)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();

      builder.HasOne(ts => ts.Teacher)
        .WithMany(t => t.Teaches)
        .HasForeignKey(ts => ts.TeacherId)
        .IsRequired();


      builder.HasOne(ts => ts.Class)
        .WithMany(c => c.Teaches)
        .HasForeignKey(ts => ts.ClassId)
        .IsRequired();

      builder.HasOne(ts => ts.Course)
        .WithMany(c => c.Teaches)
        .HasForeignKey(ts => ts.CourseCode)
        .IsRequired();
    }
  }
}