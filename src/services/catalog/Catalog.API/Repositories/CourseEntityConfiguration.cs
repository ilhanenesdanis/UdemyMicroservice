
using Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Catalog.API.Repositories;

public sealed class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {

        builder.ToCollection("courses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).HasElementName(nameof(Course.Name).ToLower()).HasMaxLength(100);
        builder.Property(x => x.Description).HasElementName(nameof(Course.Description).ToLower()).HasMaxLength(1000);
        builder.Property(x => x.Picture).HasElementName(nameof(Course.Picture).ToLower());
        builder.Property(x => x.CreateDate).HasElementName(nameof(Course.CreateDate).ToLower());
        builder.Property(x => x.UserId).HasElementName(nameof(Course.UserId).ToLower());
        builder.Property(x => x.CategoryId).HasElementName(nameof(Course.CategoryId).ToLower());
        builder.Ignore(x => x.Category);
        builder.OwnsOne(x => x.Feature, feature =>
       {
           feature.HasElementName(nameof(Feature).ToLower());
           feature.Property(x => x.Duration).HasElementName(nameof(Feature.Duration).ToLower());
           feature.Property(x => x.EducatorFullName).HasElementName(nameof(Feature.EducatorFullName).ToLower());
           feature.Property(x => x.Rating).HasElementName(nameof(Feature.Rating).ToLower());
       });
    }
}
