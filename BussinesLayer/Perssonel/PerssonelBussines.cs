using System;
using System.Collections.Generic;
using BussinesLayer.AccountBussines;
using BussinesLayer.PhoneBook;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Perssonel;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Perssonel
{
  public  class PerssonelBussines:IPerssonel
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
        public string PerssonelCode { get; set; }
        public string DateBirth { get; set; }
        public string PlaceBirth { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public Guid PerssonelGroup { get; set; }
        public string Education { get; set; }
        public string ContractCode { get; set; }
        public string ConStartDate { get; set; }
        public string ConEndDate { get; set; }
        public int ConTerm { get; set; }
        public bool ConStatus { get; set; }
        public int HourInDay { get; set; }
        public int MinInDay { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
        public decimal HourPrice { get; set; }
        public decimal HouseRight { get; set; }
        public decimal ChildRight { get; set; }
        public decimal BaseSallary { get; set; }
        public decimal BenLaborer { get; set; }
        public decimal OtherSallary { get; set; }
        public decimal FullSallary { get; set; }
        public int YearLeaving { get; set; }
        public decimal KasrPrice { get; set; }
        public decimal EzafePrice { get; set; }
        public decimal Bime { get; set; }
        public decimal Eydi { get; set; }
        public EnumGender Gender { get; set; }
        public EnumMaritalStatus MaritalStatus { get; set; }



        public AccountBussines.AccountBussines Account
        {
            get
            {
                var account = AccountBussines.AccountBussines.Get(Guid) ?? new AccountBussines.AccountBussines();
                account.Guid = Guid;
                account.HesabType = HesabType.A_Haqiqi;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = AccountGroupBussines.Get((int)HesabType.A_Haqiqi).Guid;
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

        public static List<PerssonelBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Perssonel.GetAll();
                return Mappings.Default.Map<List<PerssonelBussines>>(a);
            }
        }
        public static PerssonelBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Perssonel.Get(guid);
                return Mappings.Default.Map<PerssonelBussines>(a);
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

                    var a = Mappings.Default.Map<DataLayer.Models.Perssonel.Perssonel>(this);
                    var res = _context.Perssonel.Save(a);
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
        public static string NewContractCode()
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.NewContractCode();
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
        public static PerssonelBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Perssonel.Change_Status(accGuid, status);
                return Mappings.Default.Map<PerssonelBussines>(a);
            }
        }
        public static List<PerssonelBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Perssonel.Search(search);
                return Mappings.Default.Map<List<PerssonelBussines>>(a);
            }
        }
    }
}
