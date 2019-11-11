using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
    public class AccountPersistanceRepository : GenericRepository<Account>, IAccountRepository
    {
        private ModelContext _contextdb;
        public AccountPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
        public string NewCode(Guid groupGuid)
        {
            try
            {
                using (var model = new ModelContext())
                {
                    var code = model.Account.AsNoTracking().Where(q => q.GroupGuid == groupGuid).ToList()
                                   ?.Max(q => int.Parse(q.Half_Code)) ?? 0;
                    code += 1;
                    var new_code = code.ToString();
                    if (code < 10)
                    {
                        new_code = "000" + code;
                        return new_code;
                    }
                    if (code >= 10 && code < 100)
                    {
                        new_code = "00" + code;
                        return new_code;
                    }
                    if (code >= 100 && code < 1000)
                    {
                        new_code = "0" + code;
                        return new_code;
                    }

                    return new_code;
                }
            }
            catch (Exception exception)
            {
                return "0001";
            }
        }

        public bool Check_Name(string Name, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.Account.AsNoTracking().Where(q => q.Name == Name && q.Guid != guid).ToList();
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

        public bool Check_Code(string Code, Guid guid)
        {
            try
            {
                using (var contex = new ModelContext())
                {
                    var acc = contex.Account.AsNoTracking().Where(q => q.Code == Code && q.Guid != guid).ToList();
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

        public Account Change_Status(Guid accGuid, bool state)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var acc = context.Account.AsNoTracking().FirstOrDefault(q => q.Guid == accGuid);
                    acc.State = state;
                    context.Account.AddOrUpdate(acc);
                    context.SaveChanges();
                    return acc;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Account> Search(string search)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var list = context.Account.AsNoTracking()
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
