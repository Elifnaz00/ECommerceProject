using MyProject.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyProjectContext _projectContext;

        public UnitOfWork(MyProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _projectContext.SaveChangesAsync();
        }
    }
}
