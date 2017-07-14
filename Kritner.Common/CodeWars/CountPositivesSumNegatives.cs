using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.Common.CodeWars
{
    public class CountPositivesSumNegatives
    {
        public static int[] DoStuff(int[] input)
        {
            if (input == null || input.Length == 0)
                return new int[0];

            var list = input
                .ToList()
                .Select(s => new 
                {
                    CountPositives = input.Count(x => x > 0),
                    SumNegatives = input.Where(x => x < 0).Sum()
                }).First();

            return new int[] { list.CountPositives, list.SumNegatives };
        }
    }
}
