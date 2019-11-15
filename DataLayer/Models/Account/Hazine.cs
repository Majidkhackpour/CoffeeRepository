using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Interface;

namespace DataLayer.Models.Account
{
   public class Hazine:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string Half_Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
