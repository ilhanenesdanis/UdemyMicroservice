using Catalog.API.Features.Courses;
using Catalog.API.Repositories;

namespace Catalog.API.Features.Categories;

public sealed class Category : BaseEntity
{
    public Category()
    {
        Name=string.Empty;
    }
    public string Name { get; set; }
    public List<Course>? Courses { get; set; }
}
