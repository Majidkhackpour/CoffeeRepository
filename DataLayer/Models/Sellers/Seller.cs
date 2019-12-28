using System;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Sellers;

namespace DataLayer.Models.Sellers
{
   public class Seller:ISeller
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public decimal Amount_AvalDore { get; set; }
        public Guid MoeinAmountAvalDore { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string RespName { get; set; }
        public string EconomyCode { get; set; }
        public SellerType Type { get; set; }
    }
}
