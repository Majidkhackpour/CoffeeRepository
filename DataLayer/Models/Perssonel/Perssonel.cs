using System;
using System.Security.AccessControl;
using DataLayer.Enums;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Perssonel;

namespace DataLayer.Models.Perssonel
{
   public class Perssonel:IPerssonel
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Amount_AvalDore { get; set; }
        public Guid MoeinAvalDore { get; set; }
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
        public string PerssonelCode { get; set; }
        public string DateBirth { get; set; }
        public string PlaceBirth { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public Guid PerssonelGroup { get; set; }
        public string Education { get; set; }
        public string ContractCode { get; set; }
        public string ConStartDate { get; set; }
        public string ConEndDate { get; set; }
        public int ConTerm { get; set; }
        public bool ConStatus { get; set; }
        public int HourInDay { get; set; }
        public int MinInDay { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
        public decimal HourPrice { get; set; }
        public decimal HouseRight { get; set; }
        public decimal ChildRight { get; set; }
        public decimal BaseSallary { get; set; }
        public decimal BenLaborer { get; set; }
        public decimal OtherSallary { get; set; }
        public decimal FullSallary { get; set; }
        public int YearLeaving { get; set; }
        public decimal KasrPrice { get; set; }
        public decimal EzafePrice { get; set; }
        public decimal Bime { get; set; }
        public decimal Eydi { get; set; }
        public EnumGender Gender { get; set; }
        public EnumMaritalStatus MaritalStatus { get; set; }
    }
}
