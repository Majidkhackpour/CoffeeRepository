using System;
using DataLayer.Enums;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
   public class MoeinHesab:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public bool Status { get; set; }
        public bool System { get; set; }
        public Guid KolGuid { get; set; }
        public string Description { get; set; }
        public EnumMahiat Mahiat { get; set; }
        public KolHesab KolHesab { get; set; }
    }
}
