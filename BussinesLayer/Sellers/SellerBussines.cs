using System;
using System.Collections.Generic;
using BussinesLayer.AccountBussines;
using BussinesLayer.Perssonel;
using BussinesLayer.PhoneBook;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Sellers;
using DataLayer.Models.Account;
using DataLayer.Models.Sellers;
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


        public AccountBussines.AccountBussines Account
        {
            get
            {
                var account = AccountBussines.AccountBussines.Get(Guid) ?? new AccountBussines.AccountBussines();
                account.Guid =Guid;
                account.HesabType = HesabType.A_Haqiqi;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = Type == SellerType.A_Haqiqi
                    ? AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Guid
                    : AccountGroupBussines.Get((int)HesabType.A_Hoqouqi).Guid;
                account.Half_Code = Half_Code;
                account.Name = Name;
                account.State = Status;
                account.Amounth = Amount_AvalDore;
                return account;
            }
        }

        public PhoneBookBussines PhoneBook
        {
            get
            {
                var pb = PhoneBookBussines.Get(Guid) ?? new PhoneBookBussines();
                pb.Guid = Guid;
                pb.DateSabt = DateSabt;
                pb.Description = Description;
                pb.Name = Name;
                pb.Status = Status;
                pb.Address = Address;
                pb.Email = Email;
                pb.Mobile1 = Mobile1;
                pb.Mobile2 = Mobile2;
                pb.Phone1 = Phone1;
                pb.Phone2 = Phone2;
                pb.Pic = Pic;
                pb.PostalCode = PostalCode;
                pb.Type = EnumPhoneBookType.Partner;

                return pb;
            }
        }
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
                using (var _context = new UnitOfWork())
                {
                    tran.BeginTransaction(TranName);
                    tran.CommitTransaction(TranName);
                    var acc = Mappings.Default.Map<Account>(Account);
                    var resAccount = _context.AccountRepository.Save(acc);
                    if (!resAccount)
                    {
                        tran.RollBackTransaction(TranName);
                        return false;
                    }

                    var phb = Mappings.Default.Map<DataLayer.Models.PhoneBook.PhoneBook>(PhoneBook);
                    var resPhB = _context.PhoneBook.Save(phb);
                    if (!resPhB)
                    {
                        tran.RollBackTransaction(TranName);
                        return false;
                    }

                    var a = Mappings.Default.Map<Seller>(this);
                    var res = _context.Seller.Save(a);
                    if (!res)
                    {
                        tran.RollBackTransaction(TranName);
                        return false;
                    }

                    _context.Set_Save();
                    _context.Dispose();
                    return true;
                }
            }
            catch (Exception exception)
            {
                tran.RollBackTransaction(TranName);
                return false;
            }
        }

        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Check_Name(name, groupGuid);
        }
        public static bool Check_Code(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Check_Code(code, groupGuid);
        }

        public static SellerBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Seller.Change_Status(accGuid, status);
                return Mappings.Default.Map<SellerBussines>(a);
            }
        }
        public static List<SellerBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Seller.Search(search);
                return Mappings.Default.Map<List<SellerBussines>>(a);
            }
        }
    }
}
