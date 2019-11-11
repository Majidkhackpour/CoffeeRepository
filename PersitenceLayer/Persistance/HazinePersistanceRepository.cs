using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
    public class HazinePersistanceRepository : GenericRepository<Hazine>, IHazineRepository
    {
        private ModelContext _contextdb;
        public HazinePersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public Hazine Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Hazine.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.State = state;
                    context.Hazine.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Hazine> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Hazine.AsNoTracking()
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
