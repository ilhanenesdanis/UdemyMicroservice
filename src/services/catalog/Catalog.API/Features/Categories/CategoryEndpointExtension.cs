using Catalog.API.Features.Categories.Create;

namespace Catalog.API.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("app/categories")
            .CreateCategoryGroupItemEndpoint();
    }
}
