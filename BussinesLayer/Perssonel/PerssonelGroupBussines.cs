using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Perssonel;
using DataLayer.Models.Anbar;
using DataLayer.Models.Perssonel;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Perssonel
{
    public class PerssonelGroupBussines : IPerssonelGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }


        public static List<PerssonelGroupBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.PerssonelGroup.GetAll();
                return Mappings.Default.Map<List<PerssonelGroupBussines>>(a);
            }
        }
        public static PerssonelGroupBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.PerssonelGroup.Get(guid);
                return Mappings.Default.Map<PerssonelGroupBussines>(a);
            }
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<PerssonelGroup>(this);
                var res = _context.PerssonelGroup.Save(a);
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
        public static List<PerssonelGroupBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.PerssonelGroup.Search(search);
                return Mappings.Default.Map<List<PerssonelGroupBussines>>(a);
            }
        }
        public static PerssonelGroupBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.PerssonelGroup.Change_Status(accGuid, status);
                return Mappings.Default.Map<PerssonelGroupBussines>(a);
            }
        }


    }
}
