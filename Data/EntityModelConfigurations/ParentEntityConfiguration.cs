using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class ParentEntityConfiguration : IEntityTypeConfiguration<Parent>
  {
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
      builder.HasIndex(p => p.ParentId)
        .IsUnique(true);

      builder.Property(p => p.ParentId)
        .HasColumnType("int")
        .UseIdentityColumn(1, 1);
    }
  }
}