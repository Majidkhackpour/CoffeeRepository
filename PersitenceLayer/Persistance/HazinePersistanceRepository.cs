using System;
using System.Collections.Generic;
using DataLayer.Context;
using DataLayer.Core;
using DataLayer.Models;

namespace PersitenceLayer.Persistance
{
   public class HazinePersistanceRepository:GenericRepository<Hazine>,IHazineRepository
   {
       private ModelContext _contextdb;
        public HazinePersistanceRepository(ModelContext db) : base(db)
        {
            db = this._contextdb;
        }

        public List<Hazine> Search()
        {
            throw new NotImplementedException();
        }
    }
}
