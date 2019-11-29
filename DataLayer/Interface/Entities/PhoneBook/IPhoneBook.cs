using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.PhoneBook
{
    public interface IPhoneBook:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Pic { get; set; }
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Mobile1 { get; set; }
        string Mobile2 { get; set; }
        string Address { get; set; }
        string Fax { get; set; }
        string PostalCode { get; set; }
        string Email { get; set; }
        bool Status { get; set; }
        string ShabaCode { get; set; }
        EnumPhoneBookType Type { get; set; }
        string HesabNumber1 { get; set; }
        string HesabNumber2 { get; set; }
        string CardNumber1 { get; set; }
        string CardNumber2 { get; set; }
    }
}
