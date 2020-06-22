using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IEfRepository<T>
    {
        //IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        IQueryable<T> AsQuerable();
        T Get(Func<T, bool> predicate);
        bool Any(Func<T, bool> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
        IList<T> GetAll(Expression<Func<T, bool>> whereCondition);
        IList<T> GetAll();
    }
}
