using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
  public  class AccountGroup:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        public string Name { get; set; }
        [MaxLength(10)]
        public string Aouth_Code { get; set; }

        public int Type { get; set; }

    }
}
