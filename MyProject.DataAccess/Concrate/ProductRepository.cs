using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.CQRS.Products.Queries.Request;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    { 
        private readonly MyProjectContext _context;
        
        public ProductRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _context = myProjectContext;
        }

        public IQueryable<Product> GetFilteredProduct(GetFilteredProductQueryRequest filtered)
        {
            return _context.Products.Where(x => x.Size == filtered.size);
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

        /*
        public async Task<Product?> GetProductIncludeCategory(Guid productId)
        {
            return await _context.Products
                .Include(x => x.Category.CategoryName)
                .FirstOrDefaultAsync(x=> x.Id == productId);
            
        }

        */



    }
}
