using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class AccountGroupBussines:IAccountGroup
    {
        public static List<AccountGroup> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.AccountGroupRepository.GetAll();
        }
        public static AccountGroup Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountGroupRepository.Get(guid);
        }
        public static AccountGroup Get(int hType)
        {
            using (var _context = new UnitOfWork())
                return _context.AccountGroupRepository.Get(hType);
        }
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Aouth_Code { get; set; }
        public int Type { get; set; }
    }
}
