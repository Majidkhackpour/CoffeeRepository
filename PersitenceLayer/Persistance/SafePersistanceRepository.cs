using DataLayer.Context;
using DataLayer.Core.Sandooq;
using DataLayer.Models.Sandooq;

namespace PersitenceLayer.Persistance
{
   public class SafePersistanceRepository : GenericRepository<Safe>, ISafeRepository
    {
        private ModelContext _contextdb;
        public SafePersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
