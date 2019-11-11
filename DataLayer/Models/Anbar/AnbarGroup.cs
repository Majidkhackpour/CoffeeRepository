using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Interface;

namespace DataLayer.Models.Anbar
{
   public class AnbarGroup:IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(15)]
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Descrition { get; set; }
    }
}
