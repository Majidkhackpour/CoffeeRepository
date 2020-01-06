using System;
using DataLayer.Interface.Entities.Sandooq;

namespace DataLayer.Models.Sandooq
{
   public class Safe:ISafe
    {
        public Guid Guid { get; set; }
        public string DateSabt { get; set; }
        public string Code { get; set; }
        public string HalfCode { get; set; }
        public string Name { get; set; }
        public decimal AmountAvalDore { get; set; }
        public Guid MoeinAmountAvalDore { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
