using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Anbar;
using DataLayer.Models.Anbar;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Anbar
{
    public class AnbarGroupBussines : IAnbarGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Descrition { get; set; }

        public static List<AnbarGroupBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarGroupRepository.GetAll();
                return Mappings.Default.Map<List<AnbarGroupBussines>>(a);
            }
        }
        public static AnbarGroupBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarGroupRepository.Get(guid);
                return Mappings.Default.Map<AnbarGroupBussines>(a);
            }
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarGroupRepository.Check_Name(name, groupGuid);
        }
        public bool Save()
        {
            using (var _context = new UnitOfWork())
            {
                var a = Mappings.Default.Map<AnbarGroup>(this);
                var res = _context.AnbarGroupRepository.Save(a);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static AnbarGroupBussines Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarGroupRepository.Change_Status(accGuid, status);
                return Mappings.Default.Map<AnbarGroupBussines>(a);
            }
        }
        public static List<AnbarGroupBussines> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.AnbarGroupRepository.Search(search);
                return Mappings.Default.Map<List<AnbarGroupBussines>>(a);
            }
        }


    }
}
