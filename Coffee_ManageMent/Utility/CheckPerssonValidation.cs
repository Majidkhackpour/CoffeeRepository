using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Coffee_ManageMent.Utility
{
    public static class CheckPerssonValidation
    {
        public static bool Check_Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email == "")
            {
                return true;
            }
            else
            {
                if (Regex.IsMatch(email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                    return true;
                else
                    return false;
            }
        }
        public static bool Check_Mobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile) || mobile == "")
            {
                return true;
            }

            string phone_regexp = "[0-9]{4}[0-9]{3}[0-9]{4}";
            string phone_regexp2 = "[0-9]{3}[0-9]{3}[0-9]{4}";
            var number = new[] { mobile };
            bool Res = false;
            foreach (string phone in number)
            {
                Match m = Regex.Match(phone, phone_regexp);
                Match m2 = Regex.Match(phone, phone_regexp2);
                if (m.Success || m2.Success)
                {
                    Res = true;
                }
                else
                {
                    Res = false;
                }
            }

            return Res;
        }
        public static bool Check_NationalCode(string natCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(natCode) || natCode == "")
                {
                    return true;
                }
                char[] chArray = natCode.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (natCode)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return false;
                        break;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
