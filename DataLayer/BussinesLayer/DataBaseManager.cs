using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;

namespace DataLayer.BussinesLayer
{

    public class DataBaseManager 
    {
        private static ConcurrentDictionary<string, ModelContext> DbContext { get; set; }

        public void RollBackTransaction(string transactionName)
        {
            try
            {
                if (DbContext.TryRemove(transactionName, out var model))
                    model.Dispose();
            }
            catch (Exception ex)
            {
            }

        }

        public void BeginTransaction(string transactionName)
        {
            try
            {
                if (!DbContext.TryGetValue(transactionName, out var cotext))
                {
                    ModelContext model = new ModelContext();
                    DbContext.TryAdd(transactionName, model);
                }
            }
            catch (Exception ex)
            {
            }


        }

        public void CommitTransaction(string transactionName)
        {
            try
            {
                if (DbContext.TryGetValue(transactionName, out var cotext))
                {
                    cotext.SaveChanges();
                    DbContext.TryRemove(transactionName, out var r);
                    cotext.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Task RollBackTransactionAsync(string transactionName)
        {

            return Task.Run(() =>
             {
                 try
                 {
                     if (DbContext.TryRemove(transactionName, out var model))
                         model.Dispose();
                 }
                 catch (Exception ex)
                 {

                 }
             });

        }

        public Task BeginTransactionAsync(string transactionName)
        {
            try
            {
                return Task.Run(() =>
                {
                    if (!DbContext.TryGetValue(transactionName, out var cotext))
                    {
                        ModelContext model = new ModelContext();
                        DbContext.TryAdd(transactionName, model);
                    }
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task CommitTransactionAsync(string transactionName)
        {
            return Task.Run(() =>
             {
                 try
                 {
                     if (DbContext.TryGetValue(transactionName, out var cotext))
                     {
                         cotext.SaveChangesAsync();
                         DbContext.TryRemove(transactionName, out var r);
                         cotext.Dispose();
                     }

                     return null;
                 }
                 catch (Exception ex)
                 {
                     return null;
                 }
             });
        }

        public ModelContext GetContext(string transactionName)
        {
            try
            {
                ModelContext context;
                if (!DbContext.TryGetValue(transactionName, out context))
                {
                    context = new ModelContext();
                    DbContext.TryAdd(transactionName, context);
                }

                return context;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void RemoveContext(string transactionName)
        {
            try
            {
                DbContext.TryRemove(transactionName, out var r);
                r?.Dispose();
            }
            catch (Exception ex)
            {
            }
        }


        private class NestedDataBaseManager
        {
            internal static readonly DataBaseManager instance = new DataBaseManager();

            //Don't remove. It is necessary.
            static NestedDataBaseManager()
            {

            }
        }

        public static DataBaseManager Instance => NestedDataBaseManager.instance;

    }
}
