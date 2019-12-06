using DataLayer.Enums;

namespace DataLayer.Interface.Entities.Sellers
{
   public interface ISeller:IPersson
    {
        string RespName { get; set; }
        string EconomyCode { get; set; }
        SellerType Type { get; set; }
    }
}
