using System;
using System.Collections.Generic;
using BussinesLayer.Anbar;
using DataLayer.Enums;
using DataLayer.Interface.Entities.BankHesab;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Banks
{
    public class BanksBussines : IBanks
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
        public bool Status { get; set; }
        public string Description { get; set; }

        public static List<BanksBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.GetAll();
                return Mappings.Default.Map<List<BanksBussines>>(a);
            }
        }
        public static BanksBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Banks.Get(guid);
                return Mappings.Default.Map<BanksBussines>(a);
            }
        }
    }
}
