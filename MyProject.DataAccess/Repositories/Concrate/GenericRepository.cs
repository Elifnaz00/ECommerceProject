using Castle.Core.Logging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Repositories.Abstract;
using MyProject.DataAccess.UnitOfWorks;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repositories.Concrate
{

    public class GenericRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        private readonly MyProjectContext _myProjectContext;
        private readonly IUnitOfWork _unıtOfWork;



        public GenericRepository(MyProjectContext myProjectContext, IUnitOfWork unıtOfWork)
        {
            _myProjectContext = myProjectContext;
            _unıtOfWork = unıtOfWork;
        }



        protected DbSet<T> entity => _myProjectContext.Set<T>();


       
        public async Task<IQueryable<T?>> GetAllAsync()
        {
            return entity.AsNoTracking().AsQueryable();
        }



        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }



        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return entity.AsNoTracking().Where(predicate); ;
        }



        public async Task<T?> FindByIdAsync(Guid id)
        {

            return await entity.FindAsync(id);

        }

        public async Task<bool> AddAsync(T entity)
        {

            EntityEntry<T> entityEntry = await this.entity.AddAsync(entity);
            await _unıtOfWork.SaveChangesAsync();
            return entityEntry.State == EntityState.Added;


        }


        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            try
            {
                var value = await GetByIdAsync(id);
                if (value == null)
                {
                    return false;
                }
                else
                {
                    EntityEntry<T> entityEntry = entity.Remove(value);
                    await _unıtOfWork.SaveChangesAsync();
                    return entityEntry.State == EntityState.Deleted;


                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Update(T entity)
        {

            EntityEntry<T> entityEntry = this.entity.Update(entity);
            _unıtOfWork.SaveChangesAsync();
            return entityEntry.State == EntityState.Modified;


        }

     

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = this.entity.Remove(entity);
            _unıtOfWork?.SaveChangesAsync();
            return entityEntry.State == EntityState.Deleted;

        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await entity.AddRangeAsync(entities);
            await _unıtOfWork.SaveChangesAsync();

        }
    }
}
