using System;
using DataLayer.Interface;

namespace DataLayer.Models.Perssonel
{
   public class PerssonelGroup:IHasGuid
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
