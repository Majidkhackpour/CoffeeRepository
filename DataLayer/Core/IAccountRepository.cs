using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IAccountRepository: IRepository<Account>
    {
        string NewCode(Guid groupGuid);
        bool Check_Name(string Name, Guid guid);
        bool Check_Code(string Code, Guid guid);
        Account Change_Status(Guid accGuid, bool state);
        List<Account> Search(string search);
    }
}
