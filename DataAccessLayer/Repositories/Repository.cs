using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.ApplicationDatabase; 

namespace DataAccessLayer.Repositories
{
    public class Repository<T> : IDisposable where T : class
    {
        private readonly MainDBContext _db;
        private bool IsDisposable;
        //********************************************************************************************************************
        public Repository(MainDBContext dbContext)
        {
            IsDisposable = false;
            _db = dbContext;
        }
        public Repository()
        {
            IsDisposable = true;
            _db = new MainDBContext();
        } 
		//********************************************************************************************************************
		public MainDBContext GetContext()
        {
            return _db;
        }
        //********************************************************************************************************************
        public virtual void Add(T model)
        {
            _db.Add(model);
        }
        //********************************************************************************************************************
        public virtual void AddRange(List<T> model)
        {
            _db.AddRange(model);
        }
        //********************************************************************************************************************
        public virtual void DeleteRange(List<T> model)
        {
            _db.RemoveRange(model);
        }
        //********************************************************************************************************************
        public virtual void Update(T model)
        {
            _db.Update(model);
        }
        //********************************************************************************************************************
        public virtual void UpdateRange(List<T> model)
        {
            _db.UpdateRange(model);
        }
        //********************************************************************************************************************
        public virtual void Delete(int id)
        {
            var dbSet = _db.Set<T>();
            var entity = dbSet.Find(id);
            _db.Entry(entity).State = EntityState.Deleted;
        }
        //********************************************************************************************************************
        public virtual void Delete(T model)
        {
            _db.Remove(model);
        }
        //********************************************************************************************************************
        public virtual void Delete(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            var dbSet = _db.Set<T>();
            var query = dbSet.Where(predicate);
            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }
            dbSet.RemoveRange(query);
        }
        //********************************************************************************************************************
        public virtual T Find(int id)
        {
            var dbSet = _db.Set<T>();
            return dbSet.Find(id);
        }
        //********************************************************************************************************************
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _db.Set<T>();
            return dbSet.Where(predicate);
        }
        //********************************************************************************************************************
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = _db.Set<T>().Where(predicate);

            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }

            return query;
        }
        //********************************************************************************************************************
        public virtual IEnumerable<T> SelectAll()
        {
            var dbSet = _db.Set<T>();
            return dbSet.AsEnumerable();
        }
        //********************************************************************************************************************
        public virtual IEnumerable<T> SelectAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = _db.Set<T>().AsQueryable();

            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }

            return query.AsEnumerable();
        }
        //********************************************************************************************************************
        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _db.Set<T>();
            return dbSet.SingleOrDefault(predicate);
        }
        //********************************************************************************************************************
        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = _db.Set<T>().Where(predicate);

            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }
            return query.SingleOrDefault();
        }
        //********************************************************************************************************************
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _db.Set<T>();
            return dbSet.FirstOrDefault(predicate);
        }
        //********************************************************************************************************************
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = _db.Set<T>().Where(predicate);

            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }
            return query.FirstOrDefault();
        }
        //********************************************************************************************************************
        public virtual IQueryable<T> SelectAllAsQuerable()
        {
            var query = _db.Set<T>().AsQueryable();
            return query;
        }
        //********************************************************************************************************************
        public virtual IQueryable<T> SelectAllAsQuerable(params Expression<Func<T, object>>[] includeExpressions)
        {
            var query = _db.Set<T>().AsQueryable();

            if (includeExpressions.Any())
            {
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));
            }
            return query;
        }
        //********************************************************************************************************************
        public virtual void SaveChanges()
        {
            _db.SaveChanges();
        }
        //********************************************************************************************************************
        public void Dispose()
        {
            if (IsDisposable)
            {
                _db?.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        //********************************************************************************************************************
    }
}