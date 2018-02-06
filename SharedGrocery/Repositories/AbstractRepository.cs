using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SharedGrocery.Models;

namespace SharedGrocery.Repositories
{
    public abstract class AbstractRepository<TEntity>
    where TEntity : AbstractEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected AbstractRepository(DbContext context, DbSet<TEntity> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public TEntity FindOne(int id)
        {
            return _dbSet.FirstOrDefault(grocery => grocery.Id == id);
        }

        public ICollection<TEntity> FindAll()
        {
            return _dbSet.ToList();
        }

        public TEntity Save(TEntity entity)
        {
            var exists = FindOne(entity.Id) != null;
            var entityEntry = exists ? _dbSet.Update(entity) : _dbSet.Add(entity);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            if (FindOne(entity.Id) != null)
            {
                var entityEntry = _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}