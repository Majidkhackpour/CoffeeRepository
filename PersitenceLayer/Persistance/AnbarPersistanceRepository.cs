using DataLayer.Context;
using DataLayer.Core.Anbar;
using DataLayer.Models.Anbar;

namespace PersitenceLayer.Persistance
{
   public class AnbarPersistanceRepository:GenericRepository<Anbar>,IAnbarRepository
    {
        private ModelContext _contextdb;
        public AnbarPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
