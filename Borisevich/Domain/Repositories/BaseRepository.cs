using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;

        protected BaseRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        protected virtual IQueryable<T> All => this.Context.Set<T>().AsQueryable();

        public async Task<IReadOnlyCollection<T>> GetList()
        {
            return await this.All.ToArrayAsync();
        }

        public async Task<T> Create(T entity)
        {
            var entry = await this.Context.AddAsync(entity);
            await this.Context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var entry = this.Context.Update(entity);
            await this.Context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task Delete(T entity)
        {
            this.Context.Remove(entity);
            await this.Context.SaveChangesAsync();
        }
    }
}
