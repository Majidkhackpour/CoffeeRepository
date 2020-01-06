using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Sandooq;
using DataLayer.Models.Sandooq;

namespace PersitenceLayer.Persistance
{
   public class SafePersistanceRepository : GenericRepository<Safe>, ISafeRepository
    {
        private ModelContext _contextdb;
        public SafePersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public Safe Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Safe.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.Safe.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Safe> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Safe.AsNoTracking()
                        .Where(q => (q.Code.Contains(search)) || q.Name.Contains(search))?
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
