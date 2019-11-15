using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models.Settings;

namespace PersitenceLayer.Persistance
{
   public class AppSettingPersistanceRepository:GenericRepository<AppSetting>,IAppSetting
    {
        private ModelContext _contextdb;
        public AppSettingPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
