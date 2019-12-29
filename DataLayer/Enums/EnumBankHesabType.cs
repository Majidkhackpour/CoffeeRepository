using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
   public enum EnumBankHesabType
    {
        [PersianNameAttribute.PersianName("جاری")] Jari = 0,
        [PersianNameAttribute.PersianName("قرض الحسنه")] QarzolHasane = 1,
        [PersianNameAttribute.PersianName("پس انداز")] PasAndaz = 2
    }
}
