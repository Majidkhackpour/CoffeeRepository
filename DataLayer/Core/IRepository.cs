using System;
using System.Collections.Generic;
using DataLayer.BussinesLayer;
using DataLayer.Interface;

namespace DataLayer.Core
{
   public interface IRepository<T> where T : class, IHasGuid, new()
    {
        T Get(Guid guid);
        bool Remove(T item, string transActionName = null);
        List<T> GetAll();
       // bool Save(T item, short tryCount = 10, string transActionName = null);
        ReturnedSaveFuncInfo RemoveAll(string transActionName = null);
        bool Update(T entity);
        bool Save(T item);
    }
}
