using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryForm.Helpers
{
    internal static class ValidationMoneyHelper
    {
        public static bool ValidateString(this string str)
        {
            if(str.Any(x => char.IsLetter(x) && x != '$') == true)
                return false;

            if (str.Contains('$') == true)
            {
                string[] strings = str.Split('$');

                if (strings[1].Length != 0)
                {
                    return false;
                }
            }

            if (str.Contains('.') == true)
            {
                string buffer = str.Where(x => x != '$').IEnumerableCharToString();
                string[] strings = buffer.Split('.');

                if ((strings[1].Length == 1 || strings[1].Length == 2) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static string IEnumerableCharToString(this IEnumerable<char> chars)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in chars)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
        }
    }
}
