using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DAL.Repositories.Generic
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitiy
    {
        readonly private CarrierDbContext _context;
        public WriteRepository(CarrierDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            EntityEntry entityEntry =  Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await Table.AddRangeAsync(entities);
    }
}
