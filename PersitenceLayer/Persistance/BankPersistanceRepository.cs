using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Bank;
using DataLayer.Models.BankHesab;

namespace PersitenceLayer.Persistance
{
    public class BankPersistanceRepository : GenericRepository<Banks>, IBanksRepository
    {
        private ModelContext _contextdb;
        public BankPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public Banks Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Banks.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.Banks.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Banks> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Banks.AsNoTracking()
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
