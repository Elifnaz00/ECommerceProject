
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;


using MyProject.Bussines;
using MyProject.Bussines.Customization.Identity;
using MyProject.DataAccess.Context;

using MyProject.Entity.Entities;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();



// Add services to the container.

builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

/*
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders(); */

builder.Services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = true;

        // Other settings can be configured here
    }).AddEntityFrameworkStores<MyProjectContext>()
    .AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorDescriber>();

/*
builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<MyProjectContext>();

*/

builder.Services.AddAuthorizationBuilder();





ServicesRegistration.AddServices(builder.Services);

builder.Services.AddControllers();







// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle









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
app.UseAuthentication();
app.MapControllers();

app.Run();
