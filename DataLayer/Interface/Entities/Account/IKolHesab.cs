using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Account;

namespace DataLayer.Interface.Entities.Account
{
    public interface IKolHesab:IHasGuid
    {
       Guid Guid { get; set; }
       string DateSabt { get; set; }
       string Name { get; set; }
       string Code { get; set; }
       string Half_Code { get; set; }
       Guid GroupGuid { get; set; }
       bool Status { get; set; }
       bool System { get; set; }
       string Description { get; set; }
       HesabGroup HesabGroup { get; set; }
    }
}
