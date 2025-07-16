using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public static class Utils
    {
        public static double TruncateToTwoDecimals(double value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}