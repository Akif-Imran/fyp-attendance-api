using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      // //add constrain for unique values
      // builder.HasAlternateKey(s => s.Id);
      //
      // //generate identity(1,1)
      // builder.Property(s => s.Id)
      //   .UseIdentityColumn(1, 1)
      //   .ValueGeneratedOnAdd();
      builder.HasKey(s => s.Id);
      //Primary key
      builder.HasAlternateKey(s => s.Regno);

      //Registration No. configuration
      builder.Property(s => s.Regno)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      ////unique username
      //builder.HasIndex(s => s.Username)
      //  .IsUnique(true);

      //builder.Property(s => s.Username)
      //  .HasColumnType("varchar")
      //  .HasMaxLength(200)
      //  .IsRequired(true);

      //builder.Property(s => s.Password)
      //  .HasColumnType("varchar")
      //  .HasMaxLength(255)
      //  .IsRequired(true);

      builder.Property(s => s.FirstName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      builder.Property(s => s.LastName)
        .HasColumnType("varchar")
        .HasMaxLength(200)
        .IsRequired(true);

      //semester configuration
      builder.Property(s => s.Semester)
        .HasColumnType("int")
        .IsRequired(true);

      //discipline configuration
      builder.Property(s => s.Discipline)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);

      //degree configuration
      builder.Property(s => s.Degree)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);


      //section configuration
      builder.Property(s => s.Section)
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired(true);

      //a class has many students
      builder.HasOne(s => s.Class)
        .WithMany(c => c.Students)
        .HasForeignKey(s => s.ClassId)
        .IsRequired();

      builder.HasOne(s => s.Parent)
        .WithMany(p => p.Children)
        .HasPrincipalKey(p => p.Id)
        .HasForeignKey(s => s.ParentId)
        .IsRequired();
    }
  }
}