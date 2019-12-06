using System;
using System.Collections.Generic;
using BussinesLayer.Perssonel;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Sellers;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Sellers
{
    public class SellerBussines : ISeller
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public decimal Amount_AvalDore { get; set; }
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
        public static List<SellerBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Seller.GetAll();
                return Mappings.Default.Map<List<SellerBussines>>(a);
            }
        }
        public static SellerBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Seller.Get(guid);
                return Mappings.Default.Map<SellerBussines>(a);
            }
        }
        public bool Save()
        {
            var tran = new DataBaseManager();
            string TranName = "Tran" + System.Guid.NewGuid().ToString();
            try
            {
                //    using (var _context = new UnitOfWork())
                //    {
                //        tran.BeginTransaction(TranName);
                //        tran.CommitTransaction(TranName);
                //        var acc = Mappings.Default.Map<Account>(Account);
                //        var resAccount = _context.AccountRepository.Save(acc);
                //        if (!resAccount)
                //        {
                //            tran.RollBackTransaction(TranName);
                //            return false;
                //        }

                //        var phb = Mappings.Default.Map<DataLayer.Models.PhoneBook.PhoneBook>(PhoneBook);
                //        var resPhB = _context.PhoneBook.Save(phb);
                //        if (!resPhB)
                //        {
                //            tran.RollBackTransaction(TranName);
                //            return false;
                //        }

                //        var a = Mappings.Default.Map<DataLayer.Models.Perssonel.Perssonel>(this);
                //        var res = _context.Perssonel.Save(a);
                //        if (!res)
                //        {
                //            tran.RollBackTransaction(TranName);
                //            return false;
                //        }
                //        _context.Set_Save();
                //        _context.Dispose();
                return true;
                }
            catch (Exception exception)
            {
                tran.RollBackTransaction(TranName);
                return false;
            }
        }
    }
}
