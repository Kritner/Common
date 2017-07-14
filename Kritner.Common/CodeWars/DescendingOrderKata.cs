using System;
using System.Linq;


namespace Kritner.Common.CodeWars
{
    public class DescendingOrderKata
    {
        /// <summary>
        /// Your task is to make a function that can take any non-negative integer as a argument and return it with it's digits in descending order. Essentially, rearrange the digits to create the highest possible number.
        /// </summary>
        /// <example>
        ///         Examples:
        ///         Input: 21445 Output: 54421
        ///         Input: 145263 Output: 654321
        ///         Input: 1254859723 Output: 9875543221
        /// </example>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int DescendingOrder(int num)
        {
            if (num < 0)
                throw new ArgumentOutOfRangeException();

            var numberDigits = num.ToString().ToCharArray();

            var newString = new string (numberDigits.OrderByDescending(ob => ob).AsEnumerable().ToArray());

            int result = 0;
            int.TryParse(newString, out result);

            return result;
        }
    }
}
