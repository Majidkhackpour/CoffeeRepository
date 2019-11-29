using System;
using System.Collections.Generic;
using DataLayer.Models.Perssonel;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Perssonel
{
  public  class PerssonelBussines
    {
        public static List<DataLayer.Models.Perssonel.Perssonel> GetAll()
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.GetAll();
        }
        public static DataLayer.Models.Perssonel.Perssonel Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Get(guid);
        }
        public static bool Save(DataLayer.Models.Perssonel.Perssonel item)
        {
            using (var _context = new UnitOfWork())
            {
                var res = _context.Perssonel.Save(item);
                _context.Set_Save();
                _context.Dispose();
                return res;
            }
        }
        public static string NewContractCode()
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.NewContractCode();
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Check_Name(name, groupGuid);
        }
        public static bool Check_Code(string code, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.Perssonel.Check_Code(code, groupGuid);
        }
    }
}
