using System;
using DataLayer.Interface;

namespace DataLayer.Models.Settings
{
   public class AppSetting:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public Guid CurrentAnbar { get; set; }
    }
}
