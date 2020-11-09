using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberCore.Extentions
{
    public static class NumberExtentions
    {
        public static bool IsPrime(this int number)
        {
            if (number == 2)
            {
                return true;
            }

            if (number <= 1 || number % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i < Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
