using Microsoft.EntityFrameworkCore;
using SiteApi.Application.Interfaces.Repositories;
using SiteApi.Application.Interfaces.UnitOfWorks;
using SiteApi.Persistence.Context;
using SiteApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbConetxt dbContext;

        public UnitOfWork(AppDbConetxt dbContext)
        {
            this.dbContext = dbContext;
        }


        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();


        public int Save() => dbContext.SaveChanges();
      
        public async Task<int> SaveAsync() =>await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
