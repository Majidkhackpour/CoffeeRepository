﻿using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Anbar;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Anbar
{
   public class AnbarBussines:IAnbar
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid AnbarGroup { get; set; }
        public bool Manfi { get; set; }
        public static List<DataLayer.Models.Anbar.Anbar> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.GetAll();
        }
        public static DataLayer.Models.Anbar.Anbar Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.Get(guid);
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.Check_Name(name, groupGuid);
        }
        public static bool Save(DataLayer.Models.Anbar.Anbar item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.AnbarRepository.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static DataLayer.Models.Anbar.Anbar Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.Change_Status(accGuid, status);
        }
        public static List<DataLayer.Models.Anbar.Anbar> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.AnbarRepository.Search(search);
        }


    }
}