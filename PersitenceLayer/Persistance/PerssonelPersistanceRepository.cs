using DataLayer.Context;
using DataLayer.Core.Perssonel;
using DataLayer.Models.Perssonel;

namespace PersitenceLayer.Persistance
{
   public class PerssonelPersistanceRepository:GenericRepository<Perssonel>,IPerssonelRepository
    {
        private ModelContext _contextdb;
        public PerssonelPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
