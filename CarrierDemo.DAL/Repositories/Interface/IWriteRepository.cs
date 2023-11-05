using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DAL.Repositories.Interface
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntitiy
    {
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> RemoveAsync(int id);
        bool Update
            (T entity);
        Task<int> SaveAsync();
    }
}
