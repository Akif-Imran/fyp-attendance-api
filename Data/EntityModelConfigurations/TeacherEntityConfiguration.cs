using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class TeacherEntityConfiguration : IEntityTypeConfiguration<Teacher>
  {
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
      builder.HasKey(t=> t.Id);

      //generate identity(1,1)
      builder.Property(t => t.Id)
        .HasColumnOrder(1)
        .UseIdentityColumn(1, 1)
        .ValueGeneratedOnAdd();

      ////add constrain for unique values
      //builder.HasIndex(t=> t.Username)
      //  .IsUnique(true);

      //builder.Property(t=> t.Username)
      //  .HasColumnType("varchar")
      //  .HasColumnOrder(2)
      //  .HasMaxLength(255)
      //  .IsRequired(true);

      //builder.Property(t=> t.Password)
      //  .HasColumnType("varchar")
      //  .HasColumnOrder(3)
      //  .HasMaxLength(255)
      //  .IsRequired(true);

      builder.Property(t=> t.FirstName)
        .HasColumnType("varchar")
        .HasColumnOrder(4)
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(t=> t.LastName)
        .HasColumnType("varchar")
        .HasColumnOrder(5)
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(t => t.Department)
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired(true);
    }
  }
}