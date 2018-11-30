using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrbit.wsapi.ticket.Comum
{
    public class Util
    {
        public decimal ConvertToDecimal(string number)
        {
            decimal value;

            if (decimal.TryParse(number, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public bool IsNumeric(string number)
        {
            double num;

            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out num);

            return isNumber;
        }
    }
}
