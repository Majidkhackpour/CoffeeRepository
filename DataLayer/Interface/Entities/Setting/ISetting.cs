using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface.Entities.Setting
{
    public interface ISetting:IHasGuid
    {
       Guid Guid { get; set; }
       string DateSabt { get; set; }
       Guid CurrentAnbar { get; set; }
       Guid Customer_Motaferaqe { get; set; }
    }
}
