using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Repositories.Abstract;
using MyProject.DataAccess.Repositories.Concrate;

using MyProject.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess
{
    public class ServiceRegistration
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEntranceRepository, EntranceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          
        }
    }
}
