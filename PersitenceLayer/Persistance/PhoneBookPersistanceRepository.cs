using DataLayer.Context;
using DataLayer.Core.PhoneBook;
using DataLayer.Models.PhoneBook;

namespace PersitenceLayer.Persistance
{
   public class PhoneBookPersistanceRepository:GenericRepository<PhoneBook>,IPhoneBookRepository
    {
        private ModelContext _contextdb;
        public PhoneBookPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
