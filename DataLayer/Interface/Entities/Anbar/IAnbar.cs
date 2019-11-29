using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Entities.Anbar
{
    public interface IAnbar:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool Status { get; set; }
        Guid AnbarGroup { get; set; }
        bool Manfi { get; set; }
    }
}
