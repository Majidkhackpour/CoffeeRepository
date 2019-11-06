using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IMoeinRepository:IRepository<MoeinHesab>
    {
        string NewCode(Guid kolGuid);
        bool Check_Name(string Name, Guid guid);
        bool Check_Code(string Code, Guid guid);
        MoeinHesab Change_Status(Guid moeinguid, bool state);
        List<MoeinHesab> Search(string search);
    }
}
