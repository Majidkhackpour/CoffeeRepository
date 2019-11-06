using System;
using System.Linq;

namespace DataLayer.BussinesLayer
{
   public static class Extentions
    {
        public static string GetDisplay<T>(this T EnumItem)
        {
            try
            {
                if (typeof(T).IsEnum)
                {
                    return ((PersianNameAttribute.PersianName)typeof(T).GetFields()
                        .Single(rec => rec.Name == Enum.GetName(typeof(T), EnumItem)).GetCustomAttributes(false)
                        .First(rec => rec is PersianNameAttribute.PersianName)).Text;
                }

                return EnumItem.ToString();
            }
            catch (Exception ex)
            {
                return EnumItem.ToString();
            }
        }
    }
}
