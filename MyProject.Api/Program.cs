using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Logging;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProject.Api.Mapping;
using MyProject.DataAccess;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.CQRS.Categories.Handlers.QueryHandlers;
using MyProject.DataAccess.CQRS.Orders.Handlers;
using MyProject.DataAccess.CQRS.Products.Handlers.QueryHandlers;
using Swashbuckle.Swagger;
using System.Reflection;
using static MyProject.DataAccess.CQRS.Orders.Commands.Request.CreateOrderCommandRequest;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();



// Add services to the container.

builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));


ServiceRegistration.AddServices(builder.Services);

builder.Services.AddMediatR(typeof(GetAllCategoryQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAllProductQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetProductByCategoryQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetProductDetailQueryRequestHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateOrderCommandRequestHandler).Assembly);
builder.Services.AddMediatR(typeof(GetNewProductsQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetFilteredProductQueryHandler).Assembly);

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());







var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();