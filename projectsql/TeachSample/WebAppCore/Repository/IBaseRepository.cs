using System;
using System.Linq;
using System.Linq.Expressions;

namespace IRepository
{
    public interface IBaseRepository<T, TKey> : IDisposable where T : class
    {
        T? Find(TKey id);
        T? Find(Expression<Func<T, bool>> wherelamb);
        void Add(T entity, bool isSaveChage = true);
        bool Update(T entity, bool isSaveChage = true);
        bool Delete(T entity, bool isSaveChage = true);
        int Delete(params int[] ids);
        IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);
        int SaveChange();

    }
}
