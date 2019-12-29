using System;
using DataLayer.Enums;
using DataLayer.Interface.Entities.BankHesab;

namespace DataLayer.Models.BankHesab
{
   public class Banks:IBanks
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string HalfCode { get; set; }
        public string Name { get; set; }
        public EnumBankHesabType Type { get; set; }
        public string ShobeName { get; set; }
        public string ShobeCode { get; set; }
        public string HesabNumber { get; set; }
        public string DarandeName { get; set; }
        public bool Poss { get; set; }
        public string DateEftetah { get; set; }
        public decimal AmountAvalDore { get; set; }
        public Guid MoeinAmountAvalDore { get; set; }
    }
}
