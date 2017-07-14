using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common.CodeWars
{
    public class NthSeries
    {
        public static string seriesSum(int n)
        {
            decimal[] series = PopulateSeries(n);
            decimal result = 0;

            for (int i = 0; i < n; i++)
                result += series[i];

            return Math.Round(result, 2).ToString("F");
        }

        private static decimal[] PopulateSeries(int n)
        {
            if (n < 1)
                return new decimal[] { };

            decimal additionValue = 3;
            decimal value = 1;

            decimal[] series = new decimal[n];

            for (int i = 0; i < n; i++)
            {
                series[i] = (1 / value);
                value += additionValue;
            }

            return series;
        }
    }
}
