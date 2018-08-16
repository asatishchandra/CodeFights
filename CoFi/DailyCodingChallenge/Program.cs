using DailyCodingChallenge.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DailyCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sumExists = IsSumPossibleRetIndices(new int[] {10, 15, 3, 7 }, 17);
            //var productArray = Uber.FindProductNoDivision(new int[] { 3, 2, 1 });

            /*TreeNode tree = new TreeNode(10);
            tree.left = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.left.left = new TreeNode(3);
            tree.left.right = new TreeNode(2);
            tree.right.right = new TreeNode(11);
            tree.left.left.left = new TreeNode(3);
            tree.left.left.right = new TreeNode(-2);
            tree.left.right.left = new TreeNode(1);
            var str = Serialize(tree);
            DeSerialize(str);*/

            FirstMissingPositive(new int[] { 3,4,-1,1});

            //LongestSubstringWithAtMostKDistinctChars("abcba", 2);
        }
        #region TwoNumbersAddUptoK
        public static bool TwoNumbersAddUptoK(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return false;
            HashSet<int> complimentSet = new HashSet<int>();
            int compliment = 0;
            foreach (int num in numbers)
            {
                compliment = k - num;
                if (complimentSet.Contains(num))
                    return true;
                complimentSet.Add(compliment);
            }
            return false;
        }
        #endregion

        #region IsSumPossibleRetIndices
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
        #endregion

        #region Serialize and Deserialize binary tree
        public static string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            SerializeTree(root, sb);
            return sb.ToString();
        }

        public static void SerializeTree(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("# ");
                return;
            }
            sb.Append(string.Format("{0} ", root.val));
            SerializeTree(root.left, sb);
            SerializeTree(root.right, sb);
        }

        public static TreeNode DeSerialize(string tree)
        {
            string[] treeArr = tree.Split(' ');
            Queue<string> dataQueue = new Queue<string>();
            foreach (var data in treeArr)
            {
                dataQueue.Enqueue(data);
            }
            TreeNode root = new TreeNode(-1);
            DeSerialize(dataQueue, root);
            return root;
        }
        public static void DeSerialize(Queue<string> dataQueue, TreeNode root)
        {
            if (dataQueue.Peek() == "" || dataQueue.Peek() == "#")
            {
                dataQueue.Dequeue();
                return;
            }
            root = new TreeNode(Convert.ToInt32(dataQueue.Dequeue()));
            DeSerialize(dataQueue, root.left);
            DeSerialize(dataQueue, root.right);
        }
        #endregion

        #region FirstMissingPositive
        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            for (int i = 0; i < nums.Length; i++)
            {
                while (i + 1 != nums[i] && nums[i] > 0 && nums[i] < nums.Length)
                {
                    int v = nums[i];
                    nums[i] = nums[v - 1];
                    nums[v - 1] = v;
                    if (nums[i] == nums[v - 1])
                        break;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i)
                    return i;
            }
            return nums.Length + 1;
        }
        #endregion

        #region FindProductNoDivision
        public static int[] FindProductNoDivision(int[] numbers)
        {
            int[] retArray = new int[numbers.Length];
            retArray[0] = 1;
            int j = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                retArray[i] = retArray[i - 1] * numbers[j];
                j++;
            }

            int right = 1;
            for (int k = numbers.Length - 1; k >= 0; k--)
            {
                retArray[k] = retArray[k] * right;
                right = right * numbers[k];
            }

            return retArray;
        }
        #endregion

        #region LongestSubstringWithAtMostKDistinctChars
        public static string LongestSubstringWithAtMostKDistinctChars(string input, int k)
        {
            int[] ipArr = new int[128];
            // Otherwise take a window with first element in it.
            // start and end variables.
            int curr_start = 0, curr_end = 0;

            // Also initialize values for result longest window
            int max_window_size = 0, max_window_start = 0;

            //ipArr[input[0]]++;

            // Start from the second character and add characters
            for (var i = 0; i < input.Length; i++)
            {
                ipArr[input[i]]++;
                curr_end++;

                // If there are more than k unique characters in
                // current window, remove from left side
                while (isValid(ipArr, k))
                {
                    ipArr[input[curr_start]]--;
                    curr_start++;
                }

                // Update the max window size if required
                if (curr_end - curr_start > max_window_size)
                {
                    max_window_size = curr_end - curr_start;
                    max_window_start = curr_start;
                }

            }
            string output = input.Substring(max_window_start, max_window_size);

            return output;
        }

        private static bool isValid(int[] count, int k)
        {
            int val = 0;
            for (int i = 0; i < 128; i++)
                if (count[i] > 0)
                    val++;

            // Return true if k is greater than or equal to val
            return k <= val;
        }
        #endregion

    }
}
