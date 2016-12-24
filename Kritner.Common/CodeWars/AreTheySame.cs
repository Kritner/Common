using System;
using System.Collections.Generic;
using System.Linq;

namespace Kritner.Common.CodeWars
{
    public class AreTheySame
    {
        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int[] aSquare = a.Select(s => s * s).ToArray();
            Array.Sort(aSquare);
            Array.Sort(b);

            for (int i = 0; i < aSquare.Length; i++)
                if (aSquare[i] != b[i])
                    return false;

            return true;
        }
    }
}
