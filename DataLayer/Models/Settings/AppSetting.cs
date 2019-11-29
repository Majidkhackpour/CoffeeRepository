using System;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Setting;

namespace DataLayer.Models.Settings
{
   public class AppSetting:ISetting
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public Guid CurrentAnbar { get; set; }
        public Guid Customer_Motaferaqe { get; set; }
    }
}
