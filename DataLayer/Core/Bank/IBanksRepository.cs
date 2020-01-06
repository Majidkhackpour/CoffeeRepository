using System;
using System.Collections.Generic;
using DataLayer.Models.BankHesab;

namespace DataLayer.Core.Bank
{
    public interface IBanksRepository : IRepository<Banks>
    {
        Banks Change_Status(Guid accGuid, bool state);
        List<Banks> Search(string search);
    }
}
