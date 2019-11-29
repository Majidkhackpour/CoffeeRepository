using System;
using System.Collections.Generic;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
   public class MoeinBussines
    {
        public static List<MoeinHesab> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                return _context.MoeinRepository.GetAll();
            }

        }
        public static List<MoeinHesab> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.Search(search);
        }
        public static MoeinHesab Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.Get(guid);
        }
        public static MoeinHesab GetByCode(string code)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.GetByCode(code);
        }
        public static MoeinHesab Change_Status(Guid moeinGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.MoeinRepository.Change_Status(moeinGuid, status);
        }
        public static bool Save(MoeinHesab moein)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.MoeinRepository.Save(moein);
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
