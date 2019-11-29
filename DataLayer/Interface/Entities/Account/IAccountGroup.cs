using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Entities.Account
{
   public interface IAccountGroup:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Name { get; set; }
        string Aouth_Code { get; set; }
        int Type { get; set; }
    }
}
