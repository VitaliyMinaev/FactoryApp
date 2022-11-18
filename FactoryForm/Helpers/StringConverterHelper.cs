using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryForm.Helpers
{
    internal static class MoneyConverterHelper
    {
        public static double ParseStringToMoney(this string str)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '$')
                    break;
                
                stringBuilder.Append(str[i]);
            }

            return Convert.ToDouble(stringBuilder.ToString());
        }
        public static int ParseStringToCents(this string str)
        {
            var stringBuilder = new StringBuilder();
            bool isCents = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '$')
                    break;

                if (str[i] == '.')
                {
                    isCents = true;
                }
                else if(isCents == true)
                {
                    stringBuilder.Append(str[i]);
                }
            }

            if (isCents == false)
                return 0;

            return Convert.ToInt32(stringBuilder.ToString());
        }

        public static string ParseCentsToString(this int cents)
        {
            double money = (double)cents / 100;

            return money.ToString() + "$";
        }
    }
}
