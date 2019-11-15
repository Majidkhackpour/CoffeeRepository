using System;
using DataLayer.Interface;

namespace DataLayer.Models.Anbar
{
   public class AnbarGroup:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Descrition { get; set; }
    }
}
