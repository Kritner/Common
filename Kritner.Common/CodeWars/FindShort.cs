using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.Common.CodeWars
{
    public class FindShort
    {
        public static int FindShortestWordLength(string input)
        {
            return input
                .Split(' ')
                .Select(s => s.Length)
                .Min();
        }
    }
}
