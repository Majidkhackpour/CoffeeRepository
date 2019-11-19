using System;

namespace DataLayer.Interface
{
    public interface IHasMasterGuid
    {
        Guid MasterGuid { get; set; }
    }
}
