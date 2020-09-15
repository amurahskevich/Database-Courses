using System.Collections.Generic;
using System.Linq;
using Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class BaseRepository<TEntity>
        where TEntity : class
    {
        protected ApplicationDbContext context;
        private readonly DbSet<TEntity> dbSet;

        protected BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IReadOnlyCollection<TEntity> Get()
        {
            return this.dbSet.ToArray();
        }

        public TEntity Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);
            this.dbSet.Remove(entity);
            
            this.context.SaveChanges();
        }
    }
}
