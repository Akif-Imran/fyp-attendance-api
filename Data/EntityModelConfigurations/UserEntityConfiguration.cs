using AttendanceApi.Data.Enums;
using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class UserEntityConfiguration:IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
	 builder.HasKey(u => u.Id);

	 builder.Property(u => u.Id)
	   .HasColumnOrder(1)
	   .UseIdentityColumn(1, 1)
	   .ValueGeneratedOnAdd();

	 builder.HasIndex(u => u.Username)
	   .IsUnique(true);

	 builder.Property(u => u.Username)
	   .HasColumnType("varchar")
	   .HasMaxLength(255)
	   .IsRequired(true);

	 builder.Property(u => u.Password)
	   .HasColumnType("varchar")
	   .HasMaxLength(200)
	   .IsRequired(true);

	 builder.Property(u => u.UserType)
	   .HasConversion(
	   u => u.ToString(),
	   u => Enum.Parse<UserType>(u));
    }
  }
}
