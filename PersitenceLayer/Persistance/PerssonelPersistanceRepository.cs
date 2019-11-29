using DataLayer.Context;
using DataLayer.Core.Perssonel;
using DataLayer.Models.Perssonel;
using System;
using System.Linq;

namespace PersitenceLayer.Persistance
{
   public class PerssonelPersistanceRepository:GenericRepository<Perssonel>,IPerssonelRepository
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
                    var code = model.Perssonel.AsNoTracking()
                                   ?.Max(q => int.Parse(q.ContractCode)) ?? 0;
                    code += 1;
                    var new_code = code.ToString();
                    return new_code;
                }
            }
            catch (Exception exception)
            {
                return "1";
            }
        }

        public bool Check_Code(string code, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.Perssonel.AsNoTracking().Where(q => q.Code == code && q.Guid != guid).ToList();
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

        public bool Check_Name(string name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.Perssonel.AsNoTracking().Where(q => q.Name == name && q.Guid != guid).ToList();
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
    }
}
