using System;
using DataLayer.Enums;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Account;

namespace DataLayer.Models.Account
{
   public class MoeinHesab:IMoeinHesab
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
