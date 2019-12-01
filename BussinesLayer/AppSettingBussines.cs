using System;
using System.Collections.Generic;
using DataLayer.Core;
using DataLayer.Interface.Entities.Setting;
using DataLayer.Models.Settings;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer
{
   public class AppSettingBussines:ISetting
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public Guid CurrentAnbar { get; set; }
        public Guid Customer_Motaferaqe { get; set; }

        public static List<AppSettingBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AppSetting.GetAll();
                return Mappings.Default.Map<List<AppSettingBussines>>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<AppSetting>(this);
                var res = _context.AppSetting.Save(a);
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
        public static AppSettingBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AppSetting.Get(guid);
                return Mappings.Default.Map<AppSettingBussines>(a);
            }
        }


    }
}
