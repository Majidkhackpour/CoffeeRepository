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
    }
}
