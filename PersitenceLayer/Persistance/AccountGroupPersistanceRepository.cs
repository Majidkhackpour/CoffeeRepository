using System;
using System.Linq;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
    public class AccountGroupPersistanceRepository : GenericRepository<AccountGroup>, IAccountGroupRepository
    {
        private ModelContext _contextdb;
        public AccountGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public AccountGroup Get(int hType)
        {
            try
            {
                using (var model = new ModelContext())
                {
                    return model.AccountGroup.AsNoTracking().FirstOrDefault(q => q.Type == hType);
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
