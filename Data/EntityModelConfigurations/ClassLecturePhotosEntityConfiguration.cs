using AttendanceApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceApi.Data.EntityModelConfigurations
{
  public class ClassLecturePhotosEntityConfiguration : IEntityTypeConfiguration<ClassLecturePhotos>
  {
    public void Configure(EntityTypeBuilder<ClassLecturePhotos> builder)
    {
      builder.HasKey(clp => clp.Id);
      builder.Property(clp => clp.Id)
        .UseIdentityColumn(1, 1);

      builder.HasOne(clp => clp.Lecture)
        .WithMany(l => l.ClassLecturePhotos)
        .HasForeignKey(clp => clp.LectureId);
    }
  }
}