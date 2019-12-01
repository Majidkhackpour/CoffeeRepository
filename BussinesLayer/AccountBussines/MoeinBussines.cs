using System;
using System.Collections.Generic;
using DataLayer.Enums;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
    public class MoeinBussines : IMoeinHesab
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public bool Status { get; set; }
        public bool System { get; set; }
        public Guid KolGuid { get; set; }
        public string Description { get; set; }
        public EnumMahiat Mahiat { get; set; }
        public KolBussines KolHesab => KolBussines.Get(KolGuid);

        public static List<MoeinBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.MoeinRepository.GetAll();
                return Mappings.Default.Map<List<MoeinBussines>>(a);
            }
        }
        public static List<MoeinBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.MoeinRepository.Search(search);
                return Mappings.Default.Map<List<MoeinBussines>>(a);
            }
        }
        public static MoeinBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.MoeinRepository.Get(guid);
                return Mappings.Default.Map<MoeinBussines>(a);
            }
        }
        public static MoeinBussines GetByCode(string code)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.MoeinRepository.GetByCode(code);
                return Mappings.Default.Map<MoeinBussines>(a);
            }
        }
        public static MoeinBussines Change_Status(Guid moeinGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.MoeinRepository.Change_Status(moeinGuid, status);
                return Mappings.Default.Map<MoeinBussines>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<MoeinHesab>(this);
                var res = _context.MoeinRepository.Save(a);
                _context.Set_Save();
                return res;
            }
        }
        public static string NewCode(Guid kolGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.NewCode(kolGuid);
        }
        public static bool Check_Code(string code, Guid kolGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.Check_Code(code, kolGuid);
        }
        public static bool Check_Name(string code, Guid kolGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.Check_Name(code, kolGuid);
        }

    }
}
