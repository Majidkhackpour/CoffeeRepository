﻿using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum HesabType : short
    {
        [PersianNameAttribute.PersianName("حساب")] Hesab = 100,
        [PersianNameAttribute.PersianName("هزینه")] Hazine = 50,
        [PersianNameAttribute.PersianName("بانک")] Bank = 10,
        [PersianNameAttribute.PersianName("صندوق")] Sandouq = 20,
        [PersianNameAttribute.PersianName("اشخاص حقیقی")] A_Haqiqi = 30,
        [PersianNameAttribute.PersianName("اشخاص حقوقی")] A_Hoqouqi = 40
    }
    public enum SellerType : short
    {
        [PersianNameAttribute.PersianName("اشخاص حقیقی")] A_Haqiqi = 30,
        [PersianNameAttribute.PersianName("اشخاص حقوقی")] A_Hoqouqi = 40
    }
    public enum PayType : short
    {
        [PersianNameAttribute.PersianName("نقدی")] Naqdi = 0,
        [PersianNameAttribute.PersianName("اعتباری")] Etebari = 1
    }
}
