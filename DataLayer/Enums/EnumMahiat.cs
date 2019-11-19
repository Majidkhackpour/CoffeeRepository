using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum EnumMahiat : short
    {
        [PersianNameAttribute.PersianName("فقط بدهکار")] Bedehkar = 0,
        [PersianNameAttribute.PersianName("فقط بستانکار")] Bestankar = 1,
        [PersianNameAttribute.PersianName("بدهکار و بستانکار")] BedAndBes = 2
    }
    public enum EnumMahiatAshkhas : short
    {
        [PersianNameAttribute.PersianName("بدهکار")] Bedehkar = 1,
        [PersianNameAttribute.PersianName("بستانکار")] Bestankar = 2,
        [PersianNameAttribute.PersianName("بی حساب")] BiHesab = 0
    }
}
