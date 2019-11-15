using System.Collections.Generic;
using DataLayer.Models.Account;
using DataLayer.Models.Settings;
using PersitenceLayer.Persistance;

namespace BussinesLayer
{
   public class AppSettingBussines
    {
        public static List<AppSetting> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.AppSetting.GetAll();
        }
        public static bool Save(AppSetting appSetting)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.AppSetting.Save(appSetting);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
    }
}
