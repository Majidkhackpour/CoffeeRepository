using System;
using DataLayer.Interface;

namespace DataLayer.Models.Anbar
{
   public class Anbar:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid AnbarGroup { get; set; }
        public bool Manfi { get; set; }
    }
}
