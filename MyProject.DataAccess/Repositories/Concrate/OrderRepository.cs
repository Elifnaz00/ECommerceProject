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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(MyProjectContext myProjectContext, IUnitOfWork unıtOfWork) : base(myProjectContext, unıtOfWork)
        {
        }
    }
}
