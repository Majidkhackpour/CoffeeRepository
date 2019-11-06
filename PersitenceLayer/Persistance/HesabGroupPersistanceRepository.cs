using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models.Account;

namespace PersitenceLayer.Persistance
{
   public class HesabGroupPersistanceRepository:GenericRepository<HesabGroup>,IHesabGroupRepository
    {
        private ModelContext _contextdb;
        public HesabGroupPersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }
    }
}
