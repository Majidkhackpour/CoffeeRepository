using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Perssonel;
using DataLayer.Models.Perssonel;

namespace PersitenceLayer.Persistance
{
   public class PerssonelGroupPersistanceRepository:GenericRepository<PerssonelGroup>, IPerssonelGroupRepository
    {
        private ModelContext _contextdb;
        public PerssonelGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.PerssonelGroup.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
                    if (acc == null || acc.Count == 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public List<PerssonelGroup> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.PerssonelGroup.AsNoTracking()
                        .Where(q => q.Name.Contains(search))?
                        .ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PerssonelGroup Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.PerssonelGroup.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.PerssonelGroup.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
