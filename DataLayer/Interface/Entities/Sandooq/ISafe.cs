using System;

namespace DataLayer.Interface.Entities.Sandooq
{
   public interface ISafe:IHasGuid
    {
        string Code { get; set; }
        string HalfCode { get; set; }
        string Name { get; set; }
        decimal AmountAvalDore { get; set; }
        Guid MoeinAmountAvalDore { get; set; }
        bool Status { get; set; }
        string Description { get; set; }
    }
}
