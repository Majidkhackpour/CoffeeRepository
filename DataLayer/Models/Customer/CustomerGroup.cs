using System;
using DataLayer.Interface.Entities.Customer;

namespace DataLayer.Models.Customer
{
   public class CustomerGroup:ICustomerGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Notice { get; set; }
    }
}
