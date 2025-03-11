using MediatR;
using Shared;

namespace Catalog.API.Features.Categories.Create;

public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;

