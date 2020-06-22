﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class EfRepository<T> : IEfRepository<T> where T : class
    {
        protected IDbSet<T> _objectSet;

        public EfRepository(DbContext dbContext)
        {
            _objectSet = dbContext.Set<T>();
        }

        public IQueryable<T> AsQuerable()
        {
            return _objectSet.AsQueryable();
        }


        public IList<T> GetAll()
        {
            return this._objectSet.ToList<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return this._objectSet.Where(whereCondition).ToList<T>();
        }
        
        //public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        //{
        //    if (predicate != null)
        //    {
        //        return _objectSet.Where(predicate);
        //    }
        //    return _objectSet.AsEnumerable();
        //}

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }
        public bool Any(Func<T, bool> predicate)
        {
            return _objectSet.Any(predicate);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
    }
}
