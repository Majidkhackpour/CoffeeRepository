using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum EnumPhoneBookType 
    {
        [PersianNameAttribute.PersianName("خانواده")] Family = 0,
        [PersianNameAttribute.PersianName("دوستان")] Friend = 1,
        [PersianNameAttribute.PersianName("همکاران")] Partner = 2,
        [PersianNameAttribute.PersianName("مشتریان")] Customer = 3,
        [PersianNameAttribute.PersianName("فروشندگان")] Seller = 4,
        [PersianNameAttribute.PersianName("عمومی")] Public = 5
    }
}
