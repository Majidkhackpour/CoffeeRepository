using System;
using System.Collections.Generic;
using DataLayer.Models.Customer;

namespace DataLayer.Core.Customer
{
    public interface ICustomerGroupRepository : IRepository<CustomerGroup>
    {
        bool Check_Name(string Name, Guid guid);
        List<CustomerGroup> Search(string search);
        CustomerGroup Change_Status(Guid accGuid, bool state);
    }
}
