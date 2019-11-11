using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Anbar;
using DataLayer.Models.Anbar;

namespace PersitenceLayer.Persistance
{
   public class AnbarGroupPersistanceRepository:GenericRepository<AnbarGroup>,IAnbarGroupRepository
    {
        private ModelContext _contextdb;
        public AnbarGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.AnbarGroups.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
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

        public AnbarGroup Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.AnbarGroups.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.AnbarGroups.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<AnbarGroup> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.AnbarGroups.AsNoTracking()
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
    }
}
