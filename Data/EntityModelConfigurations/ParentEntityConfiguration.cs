using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class ParentEntityConfiguration : IEntityTypeConfiguration<Parent>
  {
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
      builder.HasKey(p => p.Id);
      //add constrain for unique values
      //builder.HasIndex(p => p.Username)
      //  .IsUnique(true);

      //generate identity(1,1)
      builder.Property(p => p.Id)
        .UseIdentityColumn(1, 1)
        .ValueGeneratedOnAdd();

      //builder.Property(p => p.Username)
      //  .HasColumnType("varchar")
      //  .HasMaxLength(255)
      //  .IsRequired(true);

      //builder.Property(p => p.Password)
      //  .HasColumnType("varchar")
      //  .HasMaxLength(255)
      //  .IsRequired(true);

      builder.Property(p => p.FirstName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(p => p.LastName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

    }
  }
}