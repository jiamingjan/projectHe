using IRepository;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebAppCore.DbModel;

namespace Repository
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class
    {
        protected VueworkdbTeachContext _context;

        protected bool disposedValue;

        public BaseRepository(VueworkdbTeachContext context)
        {
            _context = context;

        }
        public T? Find(TKey id)
        {           
            return (_context == null) ? null : _context.Set<T>().Find(id);
        }

        public T? Find(Expression<Func<T, bool>> wherelamb)
        {
            //return (_context == null) ? null : _context.Set<T>().AsNoTracking().FirstOrDefault(); //这个是无条件的找一条
            return _context.Set<T>().Where(wherelamb).FirstOrDefault(); //add by helm 有条件的找一条
        }

        public virtual bool Update(T entity, bool isSaveChage = true)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                if (isSaveChage)
                {
                    SaveChange();
                }
                return true;
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return false;
            }
        }

        public virtual bool Delete(T entity, bool isSaveChage = true)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                if (isSaveChage)
                {
                    SaveChange();
                }
                return true;
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return false;
            }

        }

        public virtual int Delete(params int[] ids)
        {
            try
            {
                foreach (var item in ids)
                {
                    var entity = _context.Set<T>().Find(item);
                    if (entity == null) //add by helm
                        return 0;
                    _context.Set<T>().Remove(entity);
                }
                SaveChange();
                return ids.Count();
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambda">null 表示全部都查</param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            try
            {
                if (whereLambda == null)
                {
                    if (isAsc)//升序
                        return _context.Set<T>().OrderBy(orderbyLambda).AsQueryable();
                    else
                        return _context.Set<T>().OrderByDescending(orderbyLambda).AsQueryable();
                }
                else
                {
                    if (isAsc)//升序
                        return _context.Set<T>().Where(whereLambda).OrderBy(orderbyLambda).AsQueryable();
                    else
                        return _context.Set<T>().Where(whereLambda).OrderByDescending(orderbyLambda).AsQueryable();
                } 
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return null!;
            }
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            try
            {
                if (whereLambda == null)
                {
                    total = _context.Set<T>().Count();
                    if (isAsc)
                    {
                        return
                        _context.Set<T>()                     
                          .OrderBy(orderbyLambda)
                          .Skip(pageSize * (pageIndex - 1))
                          .Take(pageSize)
                          .AsQueryable();
                    }
                    else
                    {
                        return
                       _context.Set<T>()                     
                         .OrderByDescending(orderbyLambda)
                         .Skip(pageSize * (pageIndex - 1))
                         .Take(pageSize)
                         .AsQueryable();
                    }
                }
                else
                {
                    total = _context.Set<T>().Where(whereLambda).Count();
                    if (isAsc)
                    {
                        return
                        _context.Set<T>()
                          .Where(whereLambda)
                          .OrderBy(orderbyLambda)
                          .Skip(pageSize * (pageIndex - 1))
                          .Take(pageSize)
                          .AsQueryable();
                    }
                    else
                    {
                        return
                       _context.Set<T>()
                         .Where(whereLambda)
                         .OrderByDescending(orderbyLambda)
                         .Skip(pageSize * (pageIndex - 1))
                         .Take(pageSize)
                         .AsQueryable();
                    }
                }
            }
            catch (Exception ex)
            {
                total = 0;
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return null!;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Add(T entity, bool isSaveChage = true)
        {
            try
            {
                _context.Set<T>().Add(entity);
                if (isSaveChage)
                {
                    SaveChange();
                }
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("logerror");
                logger.Error(ex.Message, ex);
                return ;
            }
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        //add by helm 不确定是否可用
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// helm add 2024.03.12
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VueworkdbTeachContext GetContext()
        {
            return this._context;
        }
    }
}
