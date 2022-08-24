using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
  {
    public void Configure(EntityTypeBuilder<Class> builder)
    {
      builder.HasKey(c => c.Id);


      builder.Property(c => c.ClassIdentifier)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired();
    }
  }
}