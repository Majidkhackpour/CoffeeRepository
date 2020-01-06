using System;
using System.Collections.Generic;
using DataLayer.Models.Sandooq;

namespace DataLayer.Core.Sandooq
{
    public interface ISafeRepository : IRepository<Safe>
    {
        Safe Change_Status(Guid accGuid, bool state);
        List<Safe> Search(string search);
    }
}
