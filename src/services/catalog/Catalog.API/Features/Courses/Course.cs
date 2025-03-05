

using Catalog.API.Features.Categories;
using Catalog.API.Repositories;

namespace Catalog.API.Features.Courses;

public sealed class Course : BaseEntity
{
    public Course()
    {
        Name = string.Empty;
        Description = string.Empty;
        Picture = string.Empty;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid UserId { get; set; }
    public string Picture { get; set; }
    public DateTime CreateDate { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }=default!;

    public Feature Feature { get; set; }=default!;
}
