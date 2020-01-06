using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Anbar;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Anbar
{
    public class AnbarBussines : IAnbar
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid AnbarGroup { get; set; }
        public bool Manfi { get; set; }


        public static List<AnbarBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarRepository.GetAll();
                return Mappings.Default.Map<List<AnbarBussines>>(a);
            }
        }
        public static AnbarBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarRepository.Get(guid);
                return Mappings.Default.Map<AnbarBussines>(a);
            }
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.Check_Name(name, groupGuid);
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<DataLayer.Models.Anbar.Anbar>(this);
                var res = _context.AnbarRepository.Save(a);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static AnbarBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarRepository.Change_Status(accGuid, status);
                return Mappings.Default.Map<AnbarBussines>(a);
            }
        }
        public static List<AnbarBussines> Search(string search, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarRepository.Search(search, groupGuid);
                return Mappings.Default.Map<List<AnbarBussines>>(a);
            }
        }
    }
}
