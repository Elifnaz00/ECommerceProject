using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


using MyProject.Bussines.Mapping;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.CQRS.Categories.Handlers.QueryHandlers;
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
              

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //WepApi Proje Bağımlılıkları

            services.AddAutoMapper(typeof(MapProfile));

            //GetAllCategoryQueryHandlerı refere eden dll dosyasını(assemblynin- Yani projemdeki DataAccesLayer) tarar
            services.AddMediatR(typeof(GetAllCategoryQueryHandler).Assembly);

            /*
           services.AddMediatR(Assembly.GetExecutingAssembly()); // o anda çalışmakta olan assembly'yi (derlemeyi) tarar ve MediatR'a ait handler'ları otomatik olarak IoC (Inversion of Control) container'a kaydeder.Mesela WepApi projemi ayağa kaldırdıysam WepApi projesi içindeki handlerları arar.
           services.AddMediatR(typeof(GetAllCategoryQueryHandler).Assembly);
           services.AddMediatR(typeof(GetAllProductQueryHandler).Assembly);
           services.AddMediatR(typeof(GetProductByCategoryQueryHandler).Assembly);
           services.AddMediatR(typeof(GetProductDetailQueryRequestHandler).Assembly);
           services.AddMediatR(typeof(CreateOrderCommandRequestHandler).Assembly);
           services.AddMediatR(typeof(GetNewProductsQueryHandler).Assembly);
           services.AddMediatR(typeof(GetFilteredProductQueryHandler).Assembly);
           services.AddMediatR(typeof(ContactUsCommandHandler).Assembly);

           */





        }
    }
}
