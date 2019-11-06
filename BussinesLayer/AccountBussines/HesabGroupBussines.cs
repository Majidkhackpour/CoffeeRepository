using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class HesabGroupBussines
    {
        public static List<HesabGroup> GetAll()
        {
            using (var _context=new UnitOfWork())
                return _context.HesabGroupRepository.GetAll();
        }
        public static HesabGroup Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.HesabGroupRepository.Get(guid);
        }
    }
}
