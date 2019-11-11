using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IHazineRepository:IRepository<Hazine>
    {
        Hazine Change_Status(Guid accGuid, bool state);
        List<Hazine> Search(string search);
    }
}
