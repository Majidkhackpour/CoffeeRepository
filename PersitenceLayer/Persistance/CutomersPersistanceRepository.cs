using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Customer;
using DataLayer.Models.Customer;

namespace PersitenceLayer.Persistance
{
    public class CutomersPersistanceRepository : GenericRepository<Customers>, ICustomersRepository
    {
        private ModelContext _contextdb;
        public CutomersPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public Customers Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Customers.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.Customers.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Customers> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Customers.AsNoTracking()
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
