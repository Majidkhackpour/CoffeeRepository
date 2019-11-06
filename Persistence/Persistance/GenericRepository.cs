using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.BussinesLayer;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Interface;

namespace PersitenceLayer.Persistance
{
    public class GenericRepository<T> : IRepository<T> where T : class, IHasGuid, new()
    {
        private ModelContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(ModelContext db)
        {
            this._dbContext = db;
            this._dbSet = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> where = null)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    IQueryable<T> query = _dbSet;
                    if (where != null)
                    {
                        query = query.Where(where);
                    }

                    return query.ToList();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public T Get(Guid guid)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    return _dbSet.Find(guid);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public bool Remove(T item, string transActionName = null)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (_dbContext.Entry(item).State == EntityState.Detached)
                    {
                        _dbSet.Attach(item);
                    }

                    _dbSet.Remove(item);
                    return true;
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    return false;
                    transaction.Rollback();
                }
            }
        }


        public List<T> GetAll()
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = _dbContext.Set<T>().ToList();
                    return result;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public bool Save(T item, short TryCount = 10, string transActionName = null)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Add(item);
                    return true;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public virtual bool Update(T entity)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    return true;
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    return false;
                    transaction.Rollback();
                }
            }
        }

        public bool Save(T item)
        {
            using (DbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = _dbSet.Find(item.Guid);
                    if (entity == null)
                    {
                        _dbSet.Add(item);
                    }
                    else
                    {
                        _dbContext.Entry(entity).State = EntityState.Modified;
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    transaction.Rollback();
                }
            }
        }


        public ReturnedSaveFuncInfo RemoveAll(string transActionName = null)
        {
            var tranName = string.IsNullOrEmpty(transActionName) ? Guid.NewGuid().ToString() : transActionName;
            try
            {
                var dbcontext = DataBaseManager.Instance.GetContext(tranName);
                dbcontext.Set<T>().RemoveRange(dbcontext.Set<T>().AsNoTracking().ToList());

                if (string.IsNullOrEmpty(transActionName))
                    DataBaseManager.Instance.CommitTransaction(tranName);
                return new ReturnedSaveFuncInfo();
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(transActionName))
                    DataBaseManager.Instance.RollBackTransaction(tranName);
                return new ReturnedSaveFuncInfo(ex);
            }
        }
    }
}
