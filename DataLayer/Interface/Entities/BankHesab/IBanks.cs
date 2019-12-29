using System;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.BankHesab
{
    public interface IBanks : IHasGuid
    {
        string Code { get; set; }
        string HalfCode { get; set; }
        string Name { get; set; }
        EnumBankHesabType Type { get; set; }
        string ShobeName { get; set; }
        string ShobeCode { get; set; }
        string HesabNumber { get; set; }
        string DarandeName { get; set; }
        bool Poss { get; set; }
        string DateEftetah { get; set; }
        decimal AmountAvalDore { get; set; }
        Guid MoeinAmountAvalDore { get; set; }
    }
}
