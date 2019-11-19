using System;
using System.Collections.Generic;
using DataLayer.Models.Anbar;
using PersitenceLayer.Persistance;

namespace BussinesLayer.PhoneBook
{
   public class PhoneBookBussines
    {
        public static List<DataLayer.Models.PhoneBook.PhoneBook> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.PhoneBook.GetAll();
        }
        public static DataLayer.Models.PhoneBook.PhoneBook Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.PhoneBook.Get(guid);
        }
        public static bool Save(DataLayer.Models.PhoneBook.PhoneBook item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.PhoneBook.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
    }
}
