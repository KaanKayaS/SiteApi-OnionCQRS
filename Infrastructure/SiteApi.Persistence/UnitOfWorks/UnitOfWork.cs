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
        private readonly AppDbConetxt _dbContext;
        public UnitOfWork(AppDbConetxt dbContext)
        {
            _dbContext = dbContext;
        }


        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();


        public int Save() => _dbContext.SaveChanges();
      
        public async Task<int> SaveAsync() =>await _dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
