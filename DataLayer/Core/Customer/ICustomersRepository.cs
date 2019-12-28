using System;
using System.Collections.Generic;
using DataLayer.Models.Customer;

namespace DataLayer.Core.Customer
{
    public interface ICustomersRepository : IRepository<Customers>
    {
        Customers Change_Status(Guid accGuid, bool state);
        List<Customers> Search(string search);
    }
}
