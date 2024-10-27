using Microsoft.EntityFrameworkCore.Query;
using SiteApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase , new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,   
            Func<IQueryable<T>,IIncludableQueryable<T , object>>? include = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false );


        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        Task<T> GetAsync
            (Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false); // bu iquaryble geldiği için üzerinde daha fazla sorgu yapabilirz


        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);


        //predicate: Belirli bir koşula göre (örneğin, belirli bir kullanıcı ID’si ile eşleşen kayıtlar gibi) veriyi filtrelemek için kullanılan
        //bir ifade. null olması durumunda tüm veriler getirilir.


        //include: Eager loading işlemi için kullanılır. Bu, ilişkili verileri de veritabanından getirir. Örneğin
        //, bir User tablosu ile Orders tablosu arasında ilişki varsa, User'a ait Orders verilerini de yükleyebilirsin.


        //orderBy: Veriyi belirli bir sıraya göre sıralamak için kullanılır.


        //enableTracking: Veritabanından alınan veriler üzerinde takip işlemini açar veya kapatır. Takip etkinleştirildiğinde
        //EF Core veritabanındaki veriyi izler ve otomatik güncellemeler yapabilir. Sadece veri okunacaksa kapatmak performans açısından faydalı olabilir.

    }
}
