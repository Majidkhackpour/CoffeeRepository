using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class AccountGroupBussines:IAccountGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Aouth_Code { get; set; }
        public int Type { get; set; }


        public static List<AccountGroupBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.AccountGroupRepository.GetAll();
                return Mappings.Default.Map<List<AccountGroupBussines>>(a);
            }
        }
        public static AccountGroupBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AccountGroupRepository.Get(guid);
                return Mappings.Default.Map<AccountGroupBussines>(a);
            }
        }
        public static AccountGroupBussines Get(int hType)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AccountGroupRepository.Get(hType);
                return Mappings.Default.Map<AccountGroupBussines>(a);
            }
        }
    }
}
