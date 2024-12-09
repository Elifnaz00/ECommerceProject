using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.CQRS.Products.Queries.Request;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DataAccess.Repositories.Abstract;
using MyProject.DataAccess.UnitOfWorks;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repositories.Concrate
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MyProjectContext _context;
       

        public ProductRepository(MyProjectContext myProjectContext, IUnitOfWork unıtOfWork) : base(myProjectContext, unıtOfWork)
        {
        }

        public IQueryable<Product> GetFilteredProduct(GetFilteredProductQueryRequest filtered)
        {

            var query = _context.Products.AsQueryable();

            if (filtered.Color != null)
            {

                query = query.Where(x => x.Color == filtered.Color);
            }

            if (filtered.Price != null)
            {
                query = query.Where(x => x.Price == filtered.Price);
            }

            if (filtered.Size != null)
            {
                query = query.Where(x => x.Size == filtered.Size);

            }

            if (filtered.Category != null)
            {
                query = query.Include(x => x.Category).Where(x => x.Category.CategoryName == filtered.Category);
            }

            return query;



        }

        public IQueryable<Product> GetNewArrivalProducts()
        {
            var value = _context.Products.OrderByDescending(x => x.CreateDate).Take(8);
            return value;
        }



        public IQueryable<Product> GetProductByCategory(Guid categoryId)
        {

            return _context.Products.Where(x => x.CategoryId == categoryId);
        }





    }
}
