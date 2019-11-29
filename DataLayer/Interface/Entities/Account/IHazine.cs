using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Entities.Account
{
    public interface IHazine:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Code { get; set; }
        string Half_Code { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool State { get; set; }
    }
}
