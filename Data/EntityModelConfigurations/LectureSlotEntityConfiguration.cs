using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class LectureSlotEntityConfiguration : IEntityTypeConfiguration<LectureSlot>
  {
    public void Configure(EntityTypeBuilder<LectureSlot> builder)
    {
      builder.HasKey(ls => ls.Id);

      builder.Property(ls => ls.StartTime)
        .HasConversion(
          v => v.ToShortTimeString(),
          v => TimeOnly.Parse(v)
        ).HasColumnType("varchar")
        .IsRequired();

      builder.Property(ls => ls.EndTime)
        .HasConversion(
          v => v.ToShortTimeString(),
          v => TimeOnly.Parse(v)
        ).HasColumnType("varchar")
        .IsRequired();
    }
  }
}