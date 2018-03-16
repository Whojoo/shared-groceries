﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SharedGrocery.Common.Model;

namespace SharedGrocery.GroceryService.Repository
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
            return DbSet.FirstOrDefault(grocery => grocery.Id == id);
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