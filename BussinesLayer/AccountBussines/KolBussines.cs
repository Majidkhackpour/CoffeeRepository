using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
    public class KolBussines:IKolHesab
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public Guid GroupGuid { get; set; }
        public bool Status { get; set; }
        public bool System { get; set; }
        public string Description { get; set; }
        public HesabGroup HesabGroup { get; set; }


        public static List<KolBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a= _context.KolRepository.GetAll();
                return Mappings.Default.Map<List<KolBussines>>(a);
            }
        }
        public static List<KolBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.KolRepository.Search(search);
                return Mappings.Default.Map<List<KolBussines>>(a);
            }
        }
        public static KolBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.KolRepository.Get(guid);
                return Mappings.Default.Map<KolBussines>(a);
            }
        }

        public static KolBussines GetByCode(string code)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.KolRepository.GetByCode(code);
                return Mappings.Default.Map<KolBussines>(a);
            }
        }
        public static KolBussines Change_Status(Guid kolGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.KolRepository.Change_Status(kolGuid, status);
                return Mappings.Default.Map<KolBussines>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<KolHesab>(this);
                var res = _context.KolRepository.Save(a);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static string NewCode(Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.NewCode(groupGuid);
        }
        public static bool Check_Code(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.Check_Code(code, groupGuid);
        }
        public static bool Check_Name(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.Check_Name(code, groupGuid);
        }


    }
}
