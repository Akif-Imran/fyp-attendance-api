using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
  {
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
      builder.HasKey(t => t.Id);

      //generate identity(1,1)
      builder.Property(t => t.Id)
        .HasColumnOrder(1)
        .UseIdentityColumn(1, 1)
        .ValueGeneratedOnAdd();

      //add constrain for unique values
      builder.HasIndex(t => t.Username)
        .IsUnique(true);

      builder.Property(t => t.Username)
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired(true);

      builder.Property(t => t.Password)
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired(true);

      builder.Property(t => t.FirstName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(t => t.LastName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(a => a.AccessLevel)
        .HasConversion(
          v => v.ToString(),
          v => Enum.Parse<AccessLevel>(v));
    }
  }
}