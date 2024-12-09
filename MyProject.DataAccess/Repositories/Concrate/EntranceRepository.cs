using Castle.Core.Logging;
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
    public class EntranceRepository : GenericRepository<Entrance>, IEntranceRepository
    {
        public EntranceRepository(MyProjectContext myProjectContext, IUnitOfWork unıtOfWork) : base(myProjectContext, unıtOfWork)
        {
        }
    }
}
