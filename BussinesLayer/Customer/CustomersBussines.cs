using System;
using System.Collections.Generic;
using BussinesLayer.AccountBussines;
using BussinesLayer.PhoneBook;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Customer;
using DataLayer.Models.Account;
using DataLayer.Models.Customer;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Customer
{
    public class CustomersBussines : ICustomers
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
        public Guid GroupGuid { get; set; }
        public string HesabNumber1 { get; set; }
        public string HesabNumber2 { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
        public SellerType Type { get; set; }
        public string CompanyName { get; set; }
        public string ShomareSabt { get; set; }
        public string EconomyNumber { get; set; }
        public string Job { get; set; }
        public decimal HadeEtebar { get; set; }
        public string DateBirth { get; set; }
        public string NahveAshnaei { get; set; }
        public string SubCode { get; set; }
        public int ClubPoint { get; set; }
        public PayType PayType { get; set; }


        public AccountBussines.AccountBussines Account
        {
            get
            {
                var account = AccountBussines.AccountBussines.Get(Guid) ?? new AccountBussines.AccountBussines();
                account.Guid = Guid;
                account.HesabType = Type == SellerType.A_Haqiqi ? HesabType.A_Haqiqi : HesabType.A_Hoqouqi;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = AccountGroupBussines.Get((int)Type).Guid;
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
                pb.Type = EnumPhoneBookType.Customer;

                return pb;
            }
        }

        public static List<CustomersBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Customers.GetAll();
                return Mappings.Default.Map<List<CustomersBussines>>(a);
            }
        }
        public static CustomersBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Customers.Get(guid);
                return Mappings.Default.Map<CustomersBussines>(a);
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
        public bool Save()
        {
            var tran = new DataBaseManager();
            var tranName = "Tran" + System.Guid.NewGuid().ToString();
            try
            {
                using (var context = new UnitOfWork())
                {
                    tran.BeginTransaction(tranName);
                    tran.CommitTransaction(tranName);
                    var acc = Mappings.Default.Map<Account>(Account);
                    var resAccount = context.AccountRepository.Save(acc);
                    if (!resAccount)
                    {
                        tran.RollBackTransaction(tranName);
                        return false;
                    }

                    var phb = Mappings.Default.Map<DataLayer.Models.PhoneBook.PhoneBook>(PhoneBook);
                    var resPhB = context.PhoneBook.Save(phb);
                    if (!resPhB)
                    {
                        tran.RollBackTransaction(tranName);
                        return false;
                    }

                    var a = Mappings.Default.Map<Customers>(this);
                    var res = context.Customers.Save(a);
                    if (!res)
                    {
                        tran.RollBackTransaction(tranName);
                        return false;
                    }
                    context.Set_Save();
                    context.Dispose();
                    return true;
                }
            }
            catch (Exception exception)
            {
                tran.RollBackTransaction(tranName);
                return false;
            }
        }
        public static CustomersBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Customers.Change_Status(accGuid, status);
                return Mappings.Default.Map<CustomersBussines>(a);
            }
        }
        public static List<CustomersBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Customers.Search(search);
                return Mappings.Default.Map<List<CustomersBussines>>(a);
            }
        }
    }
}
