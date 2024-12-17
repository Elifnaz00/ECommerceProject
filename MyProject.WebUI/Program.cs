using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.Context;
using MyProject.WebUI.Mapping;
using MyProject.WebUI.Models.ContactModel;
using MyProject.WebUI.Validations;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Map));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IValidator<ContactUsViewModel>, ContactUsViewModelValidator>();


// "ApiService1" adýnda bir named HttpClient örneði
builder.Services.AddHttpClient("ApiService1", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/api/v1");
    client.Timeout = TimeSpan.FromMinutes(4);
    client.DefaultRequestHeaders.Clear();
    // Diðer yapýlandýrma seçenekleri
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
