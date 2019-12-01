using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
    public class HesabGroupBussines : IHesabGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }


        public static List<HesabGroupBussines> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.HesabGroupRepository.GetAll();
                return Mappings.Default.Map<List<HesabGroupBussines>>(a);
            }
        }
        public static HesabGroupBussines Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.HesabGroupRepository.Get(guid);
                return Mappings.Default.Map<HesabGroupBussines>(a);
            }
        }


    }
}
