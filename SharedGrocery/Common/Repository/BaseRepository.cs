﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedGrocery.Common.Api.Repository;
using SharedGrocery.Common.Model;

namespace SharedGrocery.Common.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : AbstractEntity
    {
        private readonly DbContext _context;
        
        protected DbSet<TEntity> DbSet { get; }

        protected BaseRepository(DbContext context, DbSet<TEntity> dbSet)
        {
            _context = context;
            DbSet = dbSet;
        }

        public TEntity FindOne(int id)
        {
            return DbSet.Find(id);
        }

        public Task<TEntity> FindOneAsync(int id)
        {
            return DbSet.FindAsync(id);
        }

        public ICollection<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public TEntity Save(TEntity entity)
        {
            var exists = FindOne(entity.Id) != null;
            var entityEntry = exists ? DbSet.Update(entity) : DbSet.Add(entity);
            SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            if (FindOne(entity.Id) != null)
            {
                DbSet.Remove(entity);
                SaveChanges();
            }
        }

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}