using System;
using System.Collections.Generic;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class HazineBussines:IHazine
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public AccountBussines _Account
        {
            get
            {
                var account = AccountBussines.Get(Guid);
                if (account == null)
                {
                    account = new AccountBussines();
                }
                account.Guid = Guid;
                account.HesabType = HesabType.Hazine;
                account.Code = Code;
                account.DateSabt = DateSabt;
                account.Description = Description;
                account.GroupGuid = AccountGroupBussines.Get((int)HesabType.Hazine).Guid;
                account.Half_Code = Half_Code;
                account.Name = Name;
                account.State = State;
                return account;
            }
        }


        public static List<HazineBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.HazineRepository.GetAll();
                return Mappings.Default.Map<List<HazineBussines>>(a);
            }
        }
        public static HazineBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.HazineRepository.Get(guid);
                return Mappings.Default.Map<HazineBussines>(a);
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
                    var b = Mappings.Default.Map<Account>(_Account);
                    var resAccount = _context.AccountRepository.Save(b);
                    if (resAccount)
                    {
                        var a = Mappings.Default.Map<Hazine>(this);
                        var res = _context.HazineRepository.Save(a);
                        _context.Set_Save();
                        _context.Dispose();
                    }

                    return true;
                }
            }
            catch (Exception exception)
            {
                return false;
                tran.RollBackTransaction(TranName);
            }
        }
        public static HazineBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.HazineRepository.Change_Status(accGuid, status);
                return Mappings.Default.Map<HazineBussines>(a);
            }
        }
        public static List<HazineBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.HazineRepository.Search(search);
                return Mappings.Default.Map<List<HazineBussines>>(a);
            }
        }


    }
}
