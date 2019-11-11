using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;
using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IAccountGroupRepository:IRepository<AccountGroup>
   {
       AccountGroup Get(int hType);
   }
}
