using Autofac.Core;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Logging;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProject.Api;

using MyProject.Bussines;
using MyProject.DataAccess;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.CQRS.Categories.Handlers.QueryHandlers;
using MyProject.DataAccess.CQRS.Contacts.Commands.Request;
using MyProject.DataAccess.CQRS.Contacts.Handlers;
using MyProject.DataAccess.CQRS.Orders.Handlers;
using MyProject.DataAccess.CQRS.Products.Handlers.QueryHandlers;
using MyProject.Entity.Entities;
using Swashbuckle.Swagger;
using System;
using System.Reflection;
using static MyProject.DataAccess.CQRS.Orders.Commands.Request.CreateOrderCommandRequest;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();



// Add services to the container.

builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders();

/*
builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<MyProjectContext>();

*/

builder.Services.AddAuthorizationBuilder();





ServicesRegistration.AddServices(builder.Services);

builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());







var app = builder.Build();

//app.MapIdentityApi<AppUser>();

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
