using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum EnumAmount_Mahiat : short
    {
        [PersianNameAttribute.PersianName("بدهکار")] Bedehkar = 0,
        [PersianNameAttribute.PersianName("بستانکار")] Bestankar = 1,
        [PersianNameAttribute.PersianName("نامشخص")] UnKnown = 2
    }
}
