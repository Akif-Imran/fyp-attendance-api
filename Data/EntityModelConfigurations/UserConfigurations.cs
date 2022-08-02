using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class UserConfigurations : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(u => u.Id);
      //add constrain for unique values
      builder.HasIndex(u => u.Username)
        .IsUnique(true);

      //generate identity(1,1)
      builder.Property(u => u.Id)
        .HasColumnOrder(1)
        .UseIdentityColumn(1, 1)
        .ValueGeneratedOnAdd();

      builder.Property(u => u.Username)
        .HasColumnType("varchar")
        .HasColumnOrder(2)
        .HasMaxLength(255)
        .IsRequired(true);

      builder.Property(u => u.Password)
        .HasColumnType("varchar")
        .HasColumnOrder(3)
        .HasMaxLength(255)
        .IsRequired(true);

      builder.Property(u => u.FirstName)
        .HasColumnType("varchar")
        .HasColumnOrder(4)
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(u => u.LastName)
        .HasColumnType("varchar")
        .HasColumnOrder(5)
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(u => u.Role)
        .HasConversion<string>()
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);
    }
  }
}