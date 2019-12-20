using System;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.Customer
{
   public interface ICustomers:IPersson
    {
        Guid GroupGuid { get; set; }
        string HesabNumber1 { get; set; }
        string HesabNumber2 { get; set; }
        string CardNumber1 { get; set; }
        string CardNumber2 { get; set; }
        SellerType Type { get; set; }
        string CompanyName { get; set; }
        string ShomareSabt { get; set; }
        string EconomyNumber { get; set; }
        string Job { get; set; }
        decimal HadeEtebar { get; set; }
        string DateBirth { get; set; }
        string NahveAshnaei { get; set; }
        string SubCode { get; set; }
        int ClubPoint { get; set; }
        PayType PayType { get; set; }
    }
}
