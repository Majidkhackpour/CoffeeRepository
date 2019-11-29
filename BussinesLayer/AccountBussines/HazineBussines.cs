using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using Microsoft.Win32.SafeHandles;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class HazineBussines:IHazine
    {
        public static List<Hazine> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.HazineRepository.GetAll();
        }
        public static Hazine Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.HazineRepository.Get(guid);
        }
        public static bool Save(Hazine hazine)
        {
            using (var _context = new UnitOfWork())
            {
                var account = AccountBussines.Get(hazine.Guid);
                if (account==null)
                {
                    account = new Account();
                }
                account.Guid = hazine.Guid;
                account.HesabType = HesabType.Hazine;
                //account.AccountGroup = AccountGroupBussines.Get((int) HesabType.Hazine);
                account.Amounth = 0;
                account.Code = hazine.Code;
                account.DateSabt = hazine.DateSabt;
                account.Description = hazine.Description;
                account.GroupGuid = AccountGroupBussines.Get((int) HesabType.Hazine).Guid;
                account.Half_Code = hazine.Half_Code;
                account.Name = hazine.Name;
                account.State = hazine.State;
                var resAccount = _context.AccountRepository.Save(account);
                if (resAccount)
                {
                    var res = _context.HazineRepository.Save(hazine);
                    _context.Set_Save();
                    _context.Dispose();
                }
                return resAccount;
            }
        }
        public static Hazine Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.HazineRepository.Change_Status(accGuid, status);
        }
        public static List<Hazine> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.HazineRepository.Search(search);
        }

        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
