using System;
using System.Collections.Generic;
using DataLayer.Models.Account;

namespace DataLayer.Core
{
   public interface IKolRepository:IRepository<KolHesab>
   {
       string NewCode(Guid groupGuid);
       bool Check_Name(string Name, Guid guid);
       bool Check_Code(string Code, Guid guid);
       KolHesab Change_Status(Guid kolguid, bool state);
       List<KolHesab> Search(string search);
       KolHesab GetByCode(string Code);
   }
}
