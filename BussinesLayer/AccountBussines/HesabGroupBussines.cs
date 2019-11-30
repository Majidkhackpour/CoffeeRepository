using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class HesabGroupBussines:IHesabGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
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
