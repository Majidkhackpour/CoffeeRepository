using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core.Customer;
using DataLayer.Models.Customer;

namespace PersitenceLayer.Persistance
{
    public class CustomerGroupPersistanceRepository : GenericRepository<CustomerGroup>, ICustomerGroupRepository
    {
        private ModelContext _contextdb;
        public CustomerGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.CusGroup.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
                    return acc.Count == 0;
                }
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public List<CustomerGroup> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.CusGroup.AsNoTracking()
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

        public CustomerGroup Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.CusGroup.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.CusGroup.AddOrUpdate(acc);
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
