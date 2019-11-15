using System;
using System.Collections.Generic;
using DataLayer.Models.Anbar;

namespace DataLayer.Core.Anbar
{
   public interface IAnbarRepository:IRepository<Models.Anbar.Anbar>
    {
        bool Check_Name(string Name, Guid guid);
        Models.Anbar.Anbar Change_Status(Guid accGuid, bool state);
        List<Models.Anbar.Anbar> Search(string search);
    }
}
