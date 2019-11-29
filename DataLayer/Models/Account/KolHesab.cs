using System;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Account;

namespace DataLayer.Models.Account
{
   public class KolHesab:IKolHesab
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public Guid GroupGuid { get; set; }
        public bool Status { get; set; }
        public bool System { get; set; }
        public string Description { get; set; }
        public HesabGroup HesabGroup { get; set; }
    }
}
