using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Perssonel;
using DataLayer.Models.Anbar;
using DataLayer.Models.Perssonel;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Perssonel
{
   public class PerssonelGroupBussines:IPerssonelGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public static List<PerssonelGroup> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.PerssonelGroup.GetAll();
        }
        public static PerssonelGroup Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.PerssonelGroup.Get(guid);
        }
        public static bool Save(PerssonelGroup item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.PerssonelGroup.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.PerssonelGroup.Check_Name(name, groupGuid);
        }
        public static List<PerssonelGroup> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.PerssonelGroup.Search(search);
        }
        public static PerssonelGroup Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.PerssonelGroup.Change_Status(accGuid, status);
        }


    }
}
