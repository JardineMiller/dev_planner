using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using dev_planner_backend.Contexts;
using dev_planner_backend.Controllers;
using dev_planner_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace dev_planner_backend.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private ApplicationDbContext cnt;
        private DbSet<T> dbSet;
        private readonly ILogger<GenericRepository<T>> logger;

        public GenericRepository(ILogger<GenericRepository<T>> logger, ApplicationDbContext cnt)
        {
            this.cnt = cnt;
            this.dbSet = cnt.Set<T>();
            this.logger = logger;
        }

        public virtual List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            var query = includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(dbSet, (current, include) => current.Include(include));

            if (filter != null)
                query = query.Where(filter);
 
            if (orderBy != null)
                query = orderBy(query);
 
            return query.ToList();
        }
 
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;
 
            if (filter != null)
                query = query.Where(filter);
 
            if (orderBy != null)
                query = orderBy(query);
 
            return query;
        }
 
        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }
 
        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var query = includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(dbSet, (current, include) => current.Include(include));

            return query.FirstOrDefault(filter);
        }

        public virtual T Insert(T entity)
        {
            dbSet.Add(entity);
            cnt.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
            cnt.SaveChanges();
        }
 
        public virtual void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            if (cnt.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            cnt.SaveChanges();
        }
        
        


    }
}