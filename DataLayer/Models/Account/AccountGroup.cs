using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Interface;
using DataLayer.Interface.Entities.Account;

namespace DataLayer.Models.Account
{
  public  class AccountGroup:IAccountGroup
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Aouth_Code { get; set; }
        public int Type { get; set; }
    }
}
