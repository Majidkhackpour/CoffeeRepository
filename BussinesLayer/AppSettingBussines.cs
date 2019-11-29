using System;
using System.Collections.Generic;
using DataLayer.Core;
using DataLayer.Interface.Entities.Setting;
using DataLayer.Models.Settings;
using PersitenceLayer.Persistance;

namespace BussinesLayer
{
   public class AppSettingBussines:ISetting
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
        public static Guid GetLast()
        {
            using (var _context = new UnitOfWork())
                return _context.AppSetting.GetLast();
        }
        public static AppSetting Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.AppSetting.Get(guid);
        }

        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public Guid CurrentAnbar { get; set; }
        public Guid Customer_Motaferaqe { get; set; }
    }
}
