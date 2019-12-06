using DataLayer.Context;
using DataLayer.Core.Perssonel;
using DataLayer.Models.Perssonel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.BussinesLayer;

namespace PersitenceLayer.Persistance
{
    public class PerssonelPersistanceRepository : GenericRepository<Perssonel>, IPerssonelRepository
    {
        private ModelContext _contextdb;
        public PerssonelPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public string NewContractCode()
        {
            try
            {
                using (var model = new ModelContext())
                {
                    var code = model.Perssonel?.AsNoTracking()
                                   .Max(q => int.Parse(q.ContractCode)) ?? 0;
                    code += 1;
                    var newCode = code.ToString();
                    return newCode;
                }
            }
            catch (Exception exception)
            {
                return "1";
            }
        }

        public Perssonel Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Perssonel.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.Status = state;
                    context.Perssonel.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Perssonel> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Perssonel.AsNoTracking()
                        .Where(q => (q.Code.Contains(search)) || q.Name.Contains(search) ||
                                    q.PerssonelCode.Contains(search))?
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
