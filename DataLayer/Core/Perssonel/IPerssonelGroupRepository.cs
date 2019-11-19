using System;
using System.Collections.Generic;
using DataLayer.Models.Perssonel;

namespace DataLayer.Core.Perssonel
{
   public interface IPerssonelGroupRepository:IRepository<PerssonelGroup>
    {
        bool Check_Name(string Name, Guid guid);
        List<PerssonelGroup> Search(string search);
        PerssonelGroup Change_Status(Guid accGuid, bool state);
    }
}
