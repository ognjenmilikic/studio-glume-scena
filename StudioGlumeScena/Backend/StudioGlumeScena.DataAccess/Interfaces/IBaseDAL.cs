using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Interfaces
{
    public interface IBaseDAL<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        List<T> GetAll();
        T Get(long id);
        IQueryable<T> GetFor(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        void SaveChanges();
    }
}
