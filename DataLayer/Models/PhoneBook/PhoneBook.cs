using System;
using DataLayer.Enums;
using DataLayer.Interface;

namespace DataLayer.Models.PhoneBook
{
   public class PhoneBook:IHasGuid
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
    }
}
