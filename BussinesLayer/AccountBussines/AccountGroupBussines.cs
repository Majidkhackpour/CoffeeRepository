using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class AccountGroupBussines
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
    }
}
