using Catalog.API.Features.Categories;
using Catalog.API.Options;
using Catalog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();


builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseServiceExtension();

var app = builder.Build();

app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
