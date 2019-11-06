﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Core
{
   public interface IHazineRepository:IRepository<Hazine>
    {
        List<Hazine> Search();
    }
}
