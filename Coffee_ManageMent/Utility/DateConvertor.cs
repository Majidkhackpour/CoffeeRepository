using System;
using System.Globalization;
using System.Text;

namespace Coffee_ManageMent.Utility
{
   public class DateConvertor
    {
        public static string M2SH(DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            StringBuilder sb = new StringBuilder();
            sb.Append(pc.GetYear(d).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(d).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(d).ToString("00"));
            return sb.ToString();
        }
    }
}
