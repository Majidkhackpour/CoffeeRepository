using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.Account
{
    public interface IMoeinHesab:IHasGuid
    {
        Guid Guid { get; set; }
        string DateSabt { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string Half_Code { get; set; }
        bool Status { get; set; }
        bool System { get; set; }
        Guid KolGuid { get; set; }
        string Description { get; set; }
        EnumMahiat Mahiat { get; set; }
    }
}
