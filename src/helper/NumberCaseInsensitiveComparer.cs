using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VLeague.src.helper
{
    internal class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        public new int Compare(object x, object y)
        {
            try
            {
                if (x is string && IsWholeNumber((string)x) && y is string && IsWholeNumber((string)y))
                {
                    return base.Compare((object)Convert.ToInt32(x), (object)Convert.ToInt32(y));
                }
                return base.Compare(x, y);
            }
            catch
            {
                return 0;
            }
        }

        private bool IsWholeNumber(string strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }
    }
}
