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
    public class KolPersistanceRepository : GenericRepository<KolHesab>, IKolRepository
    {
        private ModelContext _contextdb;
        public KolPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public string NewCode(Guid groupGuid)
        {
            try
            {
                using (var model = new ModelContext())
                {
                    var code = model.KolHesabs.AsNoTracking().Where(q => q.GroupGuid == groupGuid).ToList()
                                   ?.Max(q => int.Parse(q.Half_Code)) ?? 0;
                    code += 1;
                    var new_code = code.ToString();
                    if (code < 10)
                    {
                        new_code = "0" + code;
                        return new_code;
                    }

                    return new_code;
                }
            }
            catch (Exception exception)
            {
                return "01";
            }
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var kol = contex.KolHesabs.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
                    if (kol == null || kol.Count == 0)
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
                    var kol = contex.KolHesabs.AsNoTracking().Where(q => q.Code == Code && q.Guid != guid).ToList();
                    if (kol == null || kol.Count == 0)
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

        public KolHesab Change_Status(Guid kolguid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var kol = context.KolHesabs.AsNoTracking().FirstOrDefault(q => q.Guid == kolguid);
                    kol.Status = state;
                    context.KolHesabs.AddOrUpdate(kol);
                    context.SaveChanges();
                    return kol;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<KolHesab> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.KolHesabs.AsNoTracking()
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

        public KolHesab GetByCode(string Code)
        {
            try
            {
                using (var context=new ModelContext())
                {
                    var kol = context.KolHesabs.AsNoTracking().FirstOrDefault(w => w.Code == Code);
                    return kol;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
