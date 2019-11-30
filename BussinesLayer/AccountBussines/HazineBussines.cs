using System;
using System.Collections.Generic;
using DataLayer.BussinesLayer;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using Microsoft.Win32.SafeHandles;
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

        public Account _Account
        {
            get
            {
                var account = AccountBussines.Get(Guid);
                if (account == null)
                {
                    account = new Account();
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
        public ReturnedSaveFuncInfo Save(Hazine hazine)
        {
            using (var _context = new UnitOfWork())
            {
                var resAccount = _context.AccountRepository.Save(_Account);
                if (resAccount)
                {
                    var res = _context.HazineRepository.Save(hazine);
                    _context.Set_Save();
                    _context.Dispose();
                }

                return new ReturnedSaveFuncInfo();
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


    }
}
