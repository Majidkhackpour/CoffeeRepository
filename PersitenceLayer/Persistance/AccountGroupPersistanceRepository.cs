using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
   public class AccountGroupPersistanceRepository:GenericRepository<AccountGroup>,IAccountGroupRepository
    {
        private ModelContext _contextdb;
        public AccountGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
