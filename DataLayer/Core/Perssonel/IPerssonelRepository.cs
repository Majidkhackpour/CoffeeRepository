using System;
using System.Collections.Generic;

namespace DataLayer.Core.Perssonel
{
    public interface IPerssonelRepository : IRepository<Models.Perssonel.Perssonel>
    {
        string NewContractCode();
        Models.Perssonel.Perssonel Change_Status(Guid accGuid, bool state);
        List<Models.Perssonel.Perssonel> Search(string search);
    }
}
