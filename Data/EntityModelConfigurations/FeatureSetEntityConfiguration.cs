using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class FeatureSetEntityConfiguration : IEntityTypeConfiguration<FeatureSet>
  {
    public void Configure(EntityTypeBuilder<FeatureSet> builder)
    {
      builder.HasKey(f => f.Id);

      builder.Property(f => f.Path)
        .HasColumnType("varchar(max)")
        .IsRequired();

      builder.Property(f => f.Pose)
        .HasColumnType("varchar")
        .HasConversion
        (
          v => v.ToString(),
          v => Enum.Parse<Pose>(v)
        )
        .HasMaxLength(255)
        .IsRequired();

      //a student has many feature sets
      builder.HasOne(f => f.Student)
        .WithMany(s => s.Features)
        .HasPrincipalKey(s => s.Regno)
        .HasForeignKey(f => f.StudentId)
        .IsRequired();
    }
  }
}