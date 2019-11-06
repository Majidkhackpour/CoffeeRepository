using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum HazineType : short
    {
        [PersianNameAttribute.PersianName("نامشخص")] UnKnown = 0,
        [PersianNameAttribute.PersianName("دستمزد مستقیم")] DirectLabor = 1,
        [PersianNameAttribute.PersianName("دستمزد غیر مستقیم")] inDirectLabor = 2,
        [PersianNameAttribute.PersianName("سربار کارخانه")] FactoryOverhead = 3,
        [PersianNameAttribute.PersianName("سایر هزینه های تولید")] Other = 4
    }
}
