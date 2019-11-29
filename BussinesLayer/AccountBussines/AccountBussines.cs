using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class AccountBussines:IAccount
    {
        public static List<Account> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.GetAll();
        }
        public static Account Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Get(guid);
        }
        public static bool Save(Account kol)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.AccountRepository.Save(kol);
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
        public static Account Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Change_Status(accGuid, status);
        }
        public static List<Account> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountRepository.Search(search);
        }

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
    }
}
