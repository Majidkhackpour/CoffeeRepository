using System;
using System.Data.Entity;
using System.Linq;
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

        public Guid GetLast()
        {
            try
            {
                using (var context=new ModelContext())
                {
                    var setting = context.AppSetting.AsNoTracking().Select(c => c.Guid).First();
                    return setting;
                }
            }
            catch (Exception e)
            {
                return Guid.Empty;
            }
        }
    }
}
