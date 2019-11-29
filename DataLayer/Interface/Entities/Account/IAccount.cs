using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Interface.Entities.Account
{
    public interface IAccount : IHasGuid
    {
        Guid Guid { get; set; }
        string Code { get; set; }
        string Half_Code { get; set; }
        string Name { get; set; }
        bool State { get; set; }
        Guid GroupGuid { get; set; }
        string DateSabt { get; set; }
        decimal Amounth { get; set; }
        string Description { get; set; }
        HesabType HesabType { get; set; }
    }
}
