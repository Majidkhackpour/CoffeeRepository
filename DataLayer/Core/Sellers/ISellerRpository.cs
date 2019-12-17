using System;
using System.Collections.Generic;
using DataLayer.Models.Sellers;

namespace DataLayer.Core.Sellers
{
    public interface ISellerRpository : IRepository<Seller>
    {
        Seller Change_Status(Guid accGuid, bool state);
        List<Seller> Search(string search);
    }
}
