using MyProject.DataAccess.Context;
using MyProject.DataAccess.Repositories.Abstract;
using MyProject.DataAccess.UnitOfWorks;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repositories.Concrate
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyProjectContext myProjectContext, IUnitOfWork unıtOfWork) : base(myProjectContext, unıtOfWork)
        {
        }
    }
}
