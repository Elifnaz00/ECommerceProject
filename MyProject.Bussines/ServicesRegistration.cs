using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


using MyProject.Bussines.Mapping;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.CQRS.Categories.Handlers.QueryHandlers;
using MyProject.DataAccess.CQRS.Contacts;
using MyProject.DataAccess.CQRS.Contacts.Commands.Request;
using MyProject.DataAccess.CQRS.Contacts.Handlers;
using MyProject.DataAccess.CQRS.Orders.Handlers;
using MyProject.DataAccess.CQRS.Products.Handlers.QueryHandlers;
using MyProject.DataAccess.UnıtOfWorks;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines
{
    public class ServicesRegistration
    {
        public static void AddServices(IServiceCollection services)
        {
            

            //DataAccces Layer Bağımlılıkları
            services.AddScoped<IEntranceRepository, EntranceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();

            services.AddScoped<IValidator<ContactUsCommandRequest>, CreateContactCommandValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateContactCommandValidator>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //WepApi Proje Bağımlılıkları

            services.AddAutoMapper(typeof(MapProfile));

            //GetAllCategoryQueryHandlerı refere eden dll dosyasını(assemblynin- Yani projemdeki DataAccesLayer) tarar
            services.AddMediatR(typeof(GetAllCategoryQueryHandler).Assembly);

          





        }
    }
}
