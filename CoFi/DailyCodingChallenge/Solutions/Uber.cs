using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Solutions
{
    public static class Uber
    {
        public static int[] FindProductNoDivision(int[] numbers)
        {
            int[] retArray = new int[numbers.Length];
            retArray[0] = 1;
            int j = 0;
            for(int i=1; i<numbers.Length; i++)
            {
                retArray[i] = retArray[i - 1] * numbers[j];
                j++;
            }

            int right = 1;
            for(int k = numbers.Length-1; k>=0; k--)
            {
                retArray[k] = retArray[k] * right;
                right = right * numbers[k];
            }

            return retArray;
        }
    }
}
