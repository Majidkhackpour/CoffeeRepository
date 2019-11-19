using DataLayer.BussinesLayer;

namespace DataLayer.Enums
{
    public enum EnumMaritalStatus
    {
        [PersianNameAttribute.PersianName("مجرد")] Mojarad = 0,
        [PersianNameAttribute.PersianName("متاهل")] Motahel = 1,
        [PersianNameAttribute.PersianName("مطلقه")] Motalaqe = 2
    }
}
