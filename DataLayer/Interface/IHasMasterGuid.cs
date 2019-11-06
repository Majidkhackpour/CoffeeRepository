using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interface
{
    public interface IHasMasterGuid
    {
        Guid MasterGuid { get; set; }
    }
}
