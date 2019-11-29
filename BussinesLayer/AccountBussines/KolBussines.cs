﻿using System;
using System.Collections.Generic;
using DataLayer.Interface.Entities.Account;
using DataLayer.Models.Account;
using PersitenceLayer.Persistance;

namespace BussinesLayer.AccountBussines
{
    public class KolBussines:IKolHesab
    {
        public static List<KolHesab> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.GetAll();
        }
        public static List<KolHesab> Search(string search)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.Search(search);
        }
        public static KolHesab Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.Get(guid);
        }

        public static KolHesab GetByCode(string code)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.GetByCode(code);
        }
        public static KolHesab Change_Status(Guid kolGuid, bool status)
        {
            using (var _context = new UnitOfWork())
                return _context.KolRepository.Change_Status(kolGuid, status);
        }
        public static bool Save(KolHesab kol)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.KolRepository.Save(kol);
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
    }
}
