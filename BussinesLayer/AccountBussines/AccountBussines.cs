using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class AccountBussines:IAccount
    {
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public Guid GroupGuid { get; set; }
        public string DateSabt { get; set; }
        public decimal Amounth { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public AccountGroupBussines AccountGroup => AccountGroupBussines.Get(GroupGuid);


        public static List<AccountBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AccountRepository.GetAll();
                return Mappings.Default.Map<List<AccountBussines>>(a);
            }
        }
        public static AccountBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AccountRepository.Get(guid);
                return Mappings.Default.Map<AccountBussines>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<Account>(this);
                var res = _context.AccountRepository.Save(a);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static string NewCode(Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.NewCode(groupGuid);
        }
        public static bool Check_Code(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Check_Code(code, groupGuid);
        }
        public static bool Check_Name(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Check_Name(code, groupGuid);
        }
        public static AccountBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AccountRepository.Change_Status(accGuid, status);
                return Mappings.Default.Map<AccountBussines>(a);
            }
        }
        public static List<AccountBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AccountRepository.Search(search);
                return Mappings.Default.Map<List<AccountBussines>>(a);
            }
        }
    }
}
