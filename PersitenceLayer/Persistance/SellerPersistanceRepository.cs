using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Sellers;
using DataLayer.Models.Sellers;

namespace PersitenceLayer.Persistance
{
    public class SellerPersistanceRepository : GenericRepository<Seller>, ISellerRpository
    {
        private ModelContext _contextdb;
        public SellerPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public Seller Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Seller.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.Seller.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Seller> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Seller.AsNoTracking()
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
