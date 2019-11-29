using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.PhoneBook;
using DataLayer.Models.Anbar;
using PersitenceLayer.Persistance;

namespace BussinesLayer.PhoneBook
{
   public class PhoneBookBussines:IPhoneBook
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

        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string ShabaCode { get; set; }
        public EnumPhoneBookType Type { get; set; }
        public string HesabNumber1 { get; set; }
        public string HesabNumber2 { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
    }
}
