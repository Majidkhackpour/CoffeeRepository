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
   public class Account:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(10)]
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public Guid GroupGuid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        public decimal Amounth { get; set; }
        public string Description { get; set; }
        public AccountGroup AccountGroup { get; set; }
    }
}
