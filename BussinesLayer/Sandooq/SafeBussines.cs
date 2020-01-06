using System;
using System.Collections.Generic;
using BussinesLayer.AccountBussines;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Sandooq;
using DataLayer.Models.Account;
using DataLayer.Models.Sandooq;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Sandooq
{
   public class SafeBussines:ISafe
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string HalfCode { get; set; }
        public string Name { get; set; }
        public decimal AmountAvalDore { get; set; }
        public Guid MoeinAmountAvalDore { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }


        public AccountBussines.AccountBussines Account
        {
            get
            {
                var account = AccountBussines.AccountBussines.Get(Guid) ?? new AccountBussines.AccountBussines();
                account.Guid = Guid;
                account.HesabType = HesabType.Sandouq;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = AccountGroupBussines.Get((int)HesabType.Sandouq).Guid;
                account.Half_Code = HalfCode;
                account.Name = Name;
                account.State = Status;
                return account;
            }
        }


        public static List<SafeBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Safe.GetAll();
                return Mappings.Default.Map<List<SafeBussines>>(a);
            }
        }
        public static SafeBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Safe.Get(guid);
                return Mappings.Default.Map<SafeBussines>(a);
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
                    var b = Mappings.Default.Map<Account>(Account);
                    var resAccount = _context.AccountRepository.Save(b);
                    if (resAccount)
                    {
                        var a = Mappings.Default.Map<Safe>(this);
                        var res = _context.Safe.Save(a);
                        _context.Set_Save();
                        _context.Dispose();
                    }

                    return true;
                }
            }
            catch (Exception exception)
            {
                tran.RollBackTransaction(TranName);
                return false;
            }
        }
        public static SafeBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Safe.Change_Status(accGuid, status);
                return Mappings.Default.Map<SafeBussines>(a);
            }
        }
        public static List<SafeBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.Safe.Search(search);
                return Mappings.Default.Map<List<SafeBussines>>(a);
            }
        }
    }
}
