using DataLayer.Context;
using DataLayer.Core.Sellers;
using DataLayer.Models.Sellers;

namespace PersitenceLayer.Persistance
{
    public class SellerPersistanceRepository : GenericRepository<Seller>, ISellerRpository
    {
        private ModelContext _contextdb;
        public SellerPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
