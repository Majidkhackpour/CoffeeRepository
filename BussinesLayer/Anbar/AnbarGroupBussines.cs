using System;
using System.Collections.Generic;
using DataLayer.Models.Anbar;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Anbar
{
   public class AnbarGroupBussines
    {
        public static List<AnbarGroup> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.GetAll();
        }
        public static AnbarGroup Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.Get(guid);
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.Check_Name(name, groupGuid);
        }
        public static bool Save(AnbarGroup item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.AnbarGroupRepository.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static AnbarGroup Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.Change_Status(accGuid, status);
        }
        public static List<AnbarGroup> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.Search(search);
        }
    }
}
