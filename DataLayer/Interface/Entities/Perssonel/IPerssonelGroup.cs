using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Entities.Perssonel
{
    public interface IPerssonelGroup:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Name { get; set; }
        bool Status { get; set; }
        string Description { get; set; }
    }
}
