using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
   public class Hazine:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(10)]
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
