using DataLayer.Context;
using DataLayer.Core.Customer;
using DataLayer.Models.Customer;

namespace PersitenceLayer.Persistance
{
    public class CutomersPersistanceRepository : GenericRepository<Customers>, ICustomersRepository
    {
        private ModelContext _contextdb;
        public CutomersPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
