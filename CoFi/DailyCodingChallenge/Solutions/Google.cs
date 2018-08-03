using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Solutions
{
    public static class Google
    {
        public static bool TwoNumbersAddUptoK(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return false;
            HashSet<int> complimentSet = new HashSet<int>();
            int compliment = 0;
            foreach(int num in numbers)
            {
                compliment = k - num;
                if (complimentSet.Contains(num))
                    return true;
                complimentSet.Add(compliment);
            }
            return false;
        }

        public static int[] IsSumPossibleRetIndices(int[] nums, int target)
        {
            Dictionary<int, int> complimentSet = new Dictionary<int, int>();
            int[] retArray = new int[2];

            if (nums.Length == 0)
                return retArray;

            for (int i = 0; i < nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (complimentSet.ContainsKey(nums[i]) && complimentSet[nums[i]] != i)
                {
                    retArray[0] = complimentSet[nums[i]];
                    retArray[1] = i;
                    return retArray;
                }
                complimentSet.Add(compliment, i);

            }

            return retArray;
        }

        public static string Serialize(TreeNode root)
        {
            if (root == null)
                return "#";
            string ret = string.Format("{0}{1}{2}", root.val, Serialize(root.left), Serialize(root.right));
            return ret;
        }

        public static TreeNode DeSerialize(TreeNode tree)
        {
            return tree;
        }
    }
}
