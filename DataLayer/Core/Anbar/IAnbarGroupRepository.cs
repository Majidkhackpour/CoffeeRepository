using System;
using System.Collections.Generic;
using DataLayer.Models.Anbar;

namespace DataLayer.Core.Anbar
{
   public interface IAnbarGroupRepository:IRepository<AnbarGroup>
    {
        bool Check_Name(string Name, Guid guid);
        AnbarGroup Change_Status(Guid accGuid, bool state);
        List<AnbarGroup> Search(string search);
    }
}
