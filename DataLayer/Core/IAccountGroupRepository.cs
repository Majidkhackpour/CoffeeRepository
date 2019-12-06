using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IAccountGroupRepository:IRepository<AccountGroup>
   {
       AccountGroup Get(int hType);
   }
}
