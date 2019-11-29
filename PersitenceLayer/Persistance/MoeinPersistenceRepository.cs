using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
   public class MoeinPersistenceRepository:GenericRepository<MoeinHesab>,IMoeinRepository
    {
        private ModelContext _contextdb;
        public MoeinPersistenceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public string NewCode(Guid kolGuid)
        {
            try
            {
                using (var model = new ModelContext())
                {
                    var code = model.MoeinHesabs.AsNoTracking().Where(q => q.KolGuid == kolGuid).ToList()
                                   ?.Max(q => int.Parse(q.Half_Code)) ?? 0;
                    code += 1;
                    var new_code = code.ToString();
                    if (code < 10)
                    {
                        new_code = "00" + code;
                        return new_code;
                    }

                    if (code >= 10 && code < 100)
                    {
                        new_code = "0" + code;
                        return new_code;
                    }

                    return new_code;
                }
            }
            catch (Exception exception)
            {
                return "001";
            }
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var moein = contex.MoeinHesabs.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
                    if (moein == null || moein.Count == 0)
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

        public bool Check_Code(string Code, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var moein = contex.MoeinHesabs.AsNoTracking().Where(q => q.Code == Code && q.Guid != guid).ToList();
                    if (moein == null || moein.Count == 0)
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

        public MoeinHesab Change_Status(Guid moeinguid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var moein = context.MoeinHesabs.AsNoTracking().FirstOrDefault(q => q.Guid == moeinguid);
                    moein.Status = state;
                    context.MoeinHesabs.AddOrUpdate(moein);
                    context.SaveChanges();
                    return moein;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<MoeinHesab> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.MoeinHesabs.AsNoTracking()
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

        public MoeinHesab GetByCode(string Code)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var moein = context.MoeinHesabs.AsNoTracking().FirstOrDefault(w => w.Code == Code);
                    return moein;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
