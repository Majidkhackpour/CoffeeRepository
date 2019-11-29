using System;

namespace DataLayer.Core.Perssonel
{
    public interface IPerssonelRepository : IRepository<Models.Perssonel.Perssonel>
    {
        string NewContractCode();
        bool Check_Code(string code, Guid guid);
        bool Check_Name(string name, Guid guid);
    }
}
