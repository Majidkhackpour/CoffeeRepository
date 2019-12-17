using System;
using System.Collections.Generic;
using DataLayer.BussinesLayer;
using DataLayer.Interface.Entities.Customer;
using DataLayer.Models.Customer;
using PersitenceLayer.Mapper;
using PersitenceLayer.Persistance;

namespace BussinesLayer.Customer
{
   public class CustomerGroupBusiness:ICustomerGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Notice { get; set; }


        public static List<CustomerGroupBusiness> GetAll()
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.GetAll();
                return Mappings.Default.Map<List<CustomerGroupBusiness>>(a);
            }
        }
        public static CustomerGroupBusiness Get(Guid guid)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.Get(guid);
                return Mappings.Default.Map<CustomerGroupBusiness>(a);
            }
        }
        public bool Save()
        {
            var tran = new DataBaseManager();
            string TranName = "Tran" + System.Guid.NewGuid().ToString();
            try
            {
                using (var _context = new UnitOfWork())
                {
                    tran.BeginTransaction(TranName);
                    tran.CommitTransaction(TranName);
                    var a = Mappings.Default.Map<CustomerGroup>(this);
                    var res = _context.CusGroup.Save(a);
                    if (!res)
                    {
                        tran.RollBackTransaction(TranName);
                        return false;
                    }

                    _context.Set_Save();
                    _context.Dispose();
                    return true;
                }
            }
            catch (Exception exception)
            {
                tran.RollBackTransaction(TranName);
                return false;
            }
        }
        public static bool Check_Name(string name, Guid groupGuid)
        {
            using (var _context = new UnitOfWork())
                return _context.CusGroup.Check_Name(name, groupGuid);
        }
        public static List<CustomerGroupBusiness> Search(string search)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.Search(search);
                return Mappings.Default.Map<List<CustomerGroupBusiness>>(a);
            }
        }
        public static CustomerGroupBusiness Change_Status(Guid accGuid, bool status)
        {
            using (var _context = new UnitOfWork())
            {
                var a = _context.CusGroup.Change_Status(accGuid, status);
                return Mappings.Default.Map<CustomerGroupBusiness>(a);
            }
        }

    }
}
