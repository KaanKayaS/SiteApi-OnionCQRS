using Microsoft.EntityFrameworkCore;
using SiteApi.Application.Interfaces.Repositories;
using SiteApi.Domain.Common;
using SiteApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbConetxt _dbContext;
        public WriteRepository(AppDbConetxt dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(()=> Table.Remove(entity));  // silme ve update işleminin asenkronu olmadığı için Run metodundan yararlandık
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));  
        }

    }
}
