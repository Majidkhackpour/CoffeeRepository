using System;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.Perssonel
{
    public interface IPerssonel:IPersson
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        decimal Amount_AvalDore { get; set; }
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
        string PerssonelCode { get; set; }
        string DateBirth { get; set; }
        string PlaceBirth { get; set; }
        string FatherName { get; set; }
        string NationalCode { get; set; }
        Guid PerssonelGroup { get; set; }
        string Education { get; set; }
        string ContractCode { get; set; }
        string ConStartDate { get; set; }
        string ConEndDate { get; set; }
        int ConTerm { get; set; }
        bool ConStatus { get; set; }
        int HourInDay { get; set; }
        int MinInDay { get; set; }
        int StartHour { get; set; }
        int StartMin { get; set; }
        int EndHour { get; set; }
        int EndMin { get; set; }
        decimal HourPrice { get; set; }
        decimal HouseRight { get; set; }
        decimal ChildRight { get; set; }
        decimal BaseSallary { get; set; }
        decimal BenLaborer { get; set; }
        decimal OtherSallary { get; set; }
        decimal FullSallary { get; set; }
        int YearLeaving { get; set; }
        decimal KasrPrice { get; set; }
        decimal EzafePrice { get; set; }
        decimal Bime { get; set; }
        decimal Eydi { get; set; }
        EnumGender Gender { get; set; }
        EnumMaritalStatus MaritalStatus { get; set; }
    }
}
