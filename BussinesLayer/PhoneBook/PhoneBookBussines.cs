using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.PhoneBook;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.PhoneBook
{
   public class PhoneBookBussines:IPhoneBook
    {
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


        public static List<PhoneBookBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.PhoneBook.GetAll();
                return Mappings.Default.Map<List<PhoneBookBussines>>(a);
            }
        }
        public static PhoneBookBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.PhoneBook.Get(guid);
                return Mappings.Default.Map<PhoneBookBussines>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<DataLayer.Models.PhoneBook.PhoneBook>(this);
                var res = _context.PhoneBook.Save(a);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }


    }
}
