using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Solutions
{
    public static class Stripe
    {
        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            for(int i=0; i<nums.Length; i++)
            {
                while(i+1 != nums[i] && nums[i] > 0 && nums[i] < nums.Length)
                {
                    int v = nums[i];
                    nums[i] = nums[v-1];
                    nums[v-1] = v;
                    if (nums[i] == nums[v - 1])
                        break;
                }
            }

            for(int i=0; i < nums.Length; i++)
            {
                if (nums[i] != i)
                    return i;
            }
            return nums.Length+1;
        }
    }
}
