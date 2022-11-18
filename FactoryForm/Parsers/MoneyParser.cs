using FactoryForm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryForm.Parsers
{
    public class MoneyParser
    {
        public static int ParseStringToCents(string str)
        {
            if (str == null)
                throw new ArgumentNullException();

            double money = str.ParseStringToMoney();

            int cents = (int)money * 100;
            cents += str.ParseStringToCents();

            return cents;
        }
    }
}
