//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace covid19.Data
{
    public interface IGenericRepository<T> where T : class
    {
        int Count();
        Task<int> CountAsync();

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);

        T Get(int id);
        Task<T> GetAsync(int id);

        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

    }
}