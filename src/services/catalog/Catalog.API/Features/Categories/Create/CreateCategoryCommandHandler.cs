using Catalog.API.Repositories;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Net;

namespace Catalog.API.Features.Categories.Create;

public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
{
    public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (existCategory)
            return ServiceResult<CreateCategoryResponse>.Error("Category already exists", $"The category name '{request.Name}' already exist", HttpStatusCode.BadRequest);

        var category = new Category
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.Name
        };

        await context.AddAsync(category, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), string.Empty);
    }
}
