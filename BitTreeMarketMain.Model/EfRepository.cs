﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public class EfRepository<T> : IRepository<T> where T : ShopEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;

            if (dbContext == null)
            {

                throw new ArgumentNullException("dbContext");
            }

            _dbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return null;

            _dbSet.Remove(entity);
            _dbContext.SaveChanges();

            return entity;

        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            if (entity == null) return null;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }

        public IQueryable<T> Items
        {
            get { return _dbSet; }
        }

        public class ProductStoreContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }
        }
    }
}
