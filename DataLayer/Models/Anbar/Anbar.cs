using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Interface;

namespace DataLayer.Models.Anbar
{
   public class Anbar:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid AnbarGroup { get; set; }
        public bool Manfi { get; set; }
    }
}
