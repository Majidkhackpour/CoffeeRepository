using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Perssonel;
using DataLayer.Models.Perssonel;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Perssonel
{
  public  class PerssonelBussines:IPerssonel
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

        public static List<DataLayer.Models.Perssonel.Perssonel> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.GetAll();
        }
        public static DataLayer.Models.Perssonel.Perssonel Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Get(guid);
        }
        public static bool Save(DataLayer.Models.Perssonel.Perssonel item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.Perssonel.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static string NewContractCode()
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.NewContractCode();
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Check_Name(name, groupGuid);
        }
        public static bool Check_Code(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Check_Code(code, groupGuid);
        }


    }
}
