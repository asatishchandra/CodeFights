using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DailyCodingChallenge
{
    class Program
    {
        private static int indexer = 0;
        static void Main(string[] args)
        {
            //var sumExists = IsSumPossibleRetIndices(new int[] {10, 15, 3, 7 }, 17);
            //var productArray = Uber.FindProductNoDivision(new int[] { 3, 2, 1 });

            /*TreeNode tree = new TreeNode(10);
            tree.i = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.i.i = new TreeNode(3);
            tree.i.right = new TreeNode(2);
            tree.right.right = new TreeNode(11);
            tree.i.i.i = new TreeNode(3);
            tree.i.i.right = new TreeNode(-2);
            tree.i.right.i = new TreeNode(1);
            var str = Serialize(tree);
            DeSerialize(str);*/

            //FirstMissingPositive(new int[] { 1, 2, 0 });

            //LongestSubstringWithAtMostKDistinctChars("abcba", 2);

            //ConstructTreeFromPreOrderInOrder(new char[] { 'a', 'b', 'd', 'e', 'c', 'f', 'g' }, new char[] { 'd', 'b', 'e', 'a', 'f', 'c', 'g'});

            //StockPrices(new int[] { 9, 11, 8, 5, 7, 10 });

            //LongestPalindromicSubstring("bananas");

            //InversionCount(new int[] { 1,3,1,5,4,2,8,6,5 });

            //StackImpl();

            //Perfect(2);

            //Max_Sum_Sub_Array(new int[] { 34, -50, 42, 14, -5, 86 });

            //MovieRating movie = new MovieRating("A", 10);
            //TreeNode<MovieRating> Node = new TreeNode<MovieRating>(movie)
            //{
            //    i = new TreeNode<MovieRating>(new MovieRating("B", 8)),
            //    right = new TreeNode<MovieRating>(new MovieRating("C", 7))
            //};
            //Node.i.i = new TreeNode<MovieRating>(new MovieRating("D", 4));
            //Node.i.right = new TreeNode<MovieRating>(new MovieRating("E", 9));

            //GetMovieRecommendations(Node, "A", 10);

            //GetThrowCount(new string[] { "5", "-2", "4", "z", "x", "9", "+", "+" }, 0);

            //InterestingCount("22:22:21","22:22:23");

            //Steps("011100");

            //solution("byebye");

            SelfDividingNumbers(1, 22);

            //ServiceTitan();

            //braces(new string[] { "{}[]()", "{[}]}" });

        }

        public static string[] braces(string[] values)
        {
            string[] retArr = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (IsBalanced(values[i]))
                {
                    retArr[i] = "YES";
                }
                else
                {
                    retArr[i] = "NO";
                }
            }
            return retArr;
        }
        //public static bool IsBalanced(string input)
        //{
        //    Stack<char> bracesStack = new Stack<char>();
        //    for (int j = 0; j < input.Length; j++)
        //    {
        //        if (bracesStack.Count == 0 && (input[j] == ')' || input[j] == '}' || input[j] == ']'))
        //        {
        //            return false;
        //        }
        //        if (input[j] == '(' || input[j] == '{' || input[j] == '[')
        //        {
        //            bracesStack.Push(input[j]);
        //        }
        //        else if (input[j] == ')' && bracesStack.Pop() != '(')
        //        {
        //            return false;
        //        }
        //        else if (input[j] == '}' && bracesStack.Pop() != '{')
        //        {
        //            return false;
        //        }
        //        else if (input[j] == ']' && bracesStack.Pop() != '[')
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool IsBalanced(string expression)
        {
            Stack<char> s = new Stack<char>();
            foreach (char c in expression)
            {
                if (c == '{') s.Push('}');
                else if (c == '[') s.Push(']');
                else if (c == '(') s.Push(')');
                else
                {
                    if (s.Count==0 || c != s.Peek())
                        return false;
                    s.Pop();
                }
            }
            return s.Count == 0;
        }

        public static List<string> fetchItemsToDisplay(List<List<string>> items, int sortParameter, int sortOrder, int itemPerPage, int pageNumber)
        {
            List<string> outList = new List<string>();
            IEnumerable<List<string>> filteredList = new List<List<string>>();
            int pageIdx = 0;
            int totalItems = items.Count();
            if (sortOrder == 0)
            {
                items.OrderBy(e => e.ElementAt(sortParameter));
            }
            else
            {
                items.OrderByDescending(e => e.ElementAt(sortParameter));
            }
            while (pageIdx <= pageNumber) {
                filteredList = items.Skip(pageIdx * pageNumber).Take(itemPerPage);
                pageIdx++;
            }
            for (int i = 0; i < filteredList.Count(); i++)
            {
                outList.Add(filteredList.ElementAt(i).ElementAt(0));
            }
            return outList;
        }

        public static void ServiceTitan()
        {
            var cloningServiceTest = new CloningServiceTest();
            var allTests = cloningServiceTest.AllTests;
            int j = 0;
            while (j==0)
            {
                //var line = Console.ReadLine();
                //if (string.IsNullOrEmpty(line))
                //    break;
                var test = allTests[j];
                try
                {
                    test.Invoke();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed on {test.GetMethodInfo().Name}.");
                }
                j++;
            }
            Console.WriteLine("Done.");
        }

        #region TwoNumbersAddUptoK 
        //https://www.dailycodingproblem.com/solution/1?token=560247314b5554b20d6cc217f5bb4cf33f76a5acb6813c59b9da10be4a8504e3d773ce3b

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

        #endregion

        #region FindProductNoDivision
        //https://www.dailycodingproblem.com/solution/2?token=c3bb79c382f785dfcaf84f7f032af2eef1b885c2ece36729e7eff706aa2117edca11e618
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

        #region Serialize and Deserialize binary tree
        //https://www.dailycodingproblem.com/solution/3?token=406c17f83c8625286b9fdf7e707a226286947ab4b3717ef017686eb658e3f05dc9067d83
        public static string Serialize(TreeNode<string> root)
        {
            StringBuilder sb = new StringBuilder();
            SerializeTree(root, sb);
            return sb.ToString();
        }

        public static void SerializeTree(TreeNode<string> root, StringBuilder sb)
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

        public static TreeNode<string> DeSerialize(string tree)
        {
            string[] treeArr = tree.Split(' ');
            Queue<string> dataQueue = new Queue<string>();
            foreach (var data in treeArr)
            {
                dataQueue.Enqueue(data);
            }
            TreeNode<string> root = new TreeNode<string>("-1");
            DeSerialize(dataQueue, root);
            return root;
        }
        public static void DeSerialize(Queue<string> dataQueue, TreeNode<string> root)
        {
            if (dataQueue.Peek() == "" || dataQueue.Peek() == "#")
            {
                dataQueue.Dequeue();
                return;
            }
            root = new TreeNode<string>(dataQueue.Dequeue());
            DeSerialize(dataQueue, root.left);
            DeSerialize(dataQueue, root.right);
        }
        #endregion

        #region FirstMissingPositive
        //https://www.dailycodingproblem.com/solution/4?token=a51c25ddc0a4c20c197c6e6a84606e99a67a53ef9254400d6307588ece30a078d127142e
        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
                return 1;
            var postiveArr = nums.Where(e => e > 0).ToArray();
            if (postiveArr.Length == 0)
                return 1;

            for (int i = 0; i < postiveArr.Length; i++)
            {
                if (Math.Abs(postiveArr[i]) - 1 < postiveArr.Length && postiveArr[Math.Abs(postiveArr[i]) - 1] > 0)
                    postiveArr[Math.Abs(postiveArr[i]) - 1] = -postiveArr[Math.Abs(postiveArr[i]) - 1];
            }
            for (int i = 0; i < postiveArr.Length; i++)
            {
                if (postiveArr[i] > 0)
                    return i + 1;
            }
            //int lowestVal = postiveArr.Select((p, i) => i).Where(e => postiveArr[e]>0).FirstOrDefault()+1;
            return postiveArr.Length + 1;
        }
        #endregion

        //5 https://www.dailycodingproblem.com/solution/5?token=ec18bb578ba2752786b7a838197a68b51efeea9e2adec0d2718cd21d1ccdd8987acd19aa
        //6 https://www.dailycodingproblem.com/solution/6?token=8c60beae5d52a2b88b794e912dfc004949c64f309929df7ba0855d16c4e2ba21e39623e9

        #region numberOfEncodings: FB
        public static int NumEncodings(string s)
        {
            if (s[0] == '0')
                return 0;
            if (s.Length <= 1)
                return 1;

            int total = 0;
            if (Convert.ToInt32(s.Substring(0, 2)) <= 26)
                total += NumEncodings(s.Substring(2));
            total += NumEncodings(s.Substring(1));
            return total;
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
                // current window, remove from i side
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

        #region Construct binary tree from preorder and inorder :GOOGLE 48
        //https://www.dailycodingproblem.com/solution/48?token=048062eb727050dd35e3682fff115c36b26166cd5bfa6f5dbae2397442272966de0c9841
        public static void ConstructTreeFromPreOrderInOrder(char[] preOrder, char[] inOrder)
        {
            int startIndex = 0;
            int endIndex = inOrder.Length;
            ConstructTree(preOrder, inOrder, startIndex, endIndex - 1);
        }

        private static TreeNode<char> ConstructTree(char[] preOrder, char[] inOrder, int startIndex, int endIndex)
        {
            if (preOrder == null || inOrder == null)
                return null;

            TreeNode<char> node = new TreeNode<char>(preOrder[indexer++]);
            if (startIndex == endIndex)
            {
                Console.WriteLine("eq");
                return node;
            }
            int inIndex = inOrder.ToList().IndexOf(preOrder[node.val]);
            node.left = ConstructTree(preOrder, inOrder, startIndex, inIndex - 1);
            node.right = ConstructTree(preOrder, inOrder, inIndex + 1, endIndex);
            Console.WriteLine("neq");
            return node;
        }

        #endregion

        #region stock prices: FB 47 
        //https://www.dailycodingproblem.com/solution/47?token=52dd83b6b14cc6bd253366149c30b06cf9d36d8c4da20d5cf5cfed3f6c5fa0f9e9aca36b
        public static void StockPrices(int[] prices)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int maxProfit = 0;

            foreach (int price in prices)
            {
                min = Math.Min(price, min);
                int currProfit = price - min;
                if (currProfit > maxProfit)
                {
                    maxProfit = currProfit;
                    max = price;
                }
            }
            Console.WriteLine(string.Format("Min Price is: {0}", min));
            Console.WriteLine(string.Format("Max Price is: {0}", max));
            Console.WriteLine(string.Format("Max Profit is: {0}", maxProfit));
        }
        #endregion

        #region longestPalindromicsubstring: Amazon 46
        //https://www.dailycodingproblem.com/solution/46?token=8b0bc59b257ffc3429b07f623f5cff45d4f6b247921895a7ab6088651a967143ceab3d93
        public static string LongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            int start = 0, end = 0;
            string result = string.Empty;

            while (end < s.Length)
            {
                if (IsPalindrome(s, start, end))
                {
                    result = (result.Length < (end - start + 1)) ? s.Substring(start, end - start + 1) : result;
                    if (start > 0)
                        start--;
                    end++;
                }
                else
                {
                    start++;
                }
            }
            return result;
        }

        private static bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
        #endregion

        #region InversionCount: Google #44
        //https://www.dailycodingproblem.com/solution/44?token=c3ed5b057554b30e1ded9b91c261a8182018c427dcdbdf6afb9cc97bd14ddc54022a8184
        public static int InversionCount(int[] nums)
        {
            if (nums == null || nums.Length == 0 || nums.Length == 1)
                return 0;
            int start = 0;
            int end = 0;
            int invCount = 0;
            while (start != nums.Length - 1 && end != nums.Length - 1)
            {
                end++;
                if (nums[start] > nums[end])
                {
                    invCount++;
                }
                else if (end == nums.Length - 1 && start != nums.Length)
                {
                    start++;
                    end = start;
                }
            }
            return invCount;
        }
        #endregion

        #region StackImpl: Amazon #43
        public static void StackImpl()
        {
            var stackImpl = new StackImpl();
            stackImpl.Push(10);
            stackImpl.Push(34);
            stackImpl.Push(60);
            stackImpl.Push(400);
            stackImpl.Push(50);

            Console.WriteLine(stackImpl.Pop());
            Console.WriteLine(stackImpl.Pop());
            Console.WriteLine(stackImpl.Pop());
            Console.WriteLine(stackImpl.Pop());
            Console.WriteLine(stackImpl.Max);
        }
        #endregion

        #region Perfect: Microsoft #70
        public static int Perfect(int n)
        {
            int i = 0;
            int current = 0;

            while (current < n)
            {
                i++;
                if (Calc_Sum(i) == 10)
                    current++;
            }

            return i;
        }

        private static int Calc_Sum(int n)
        {
            int current = 0;
            while (n > 0)
            {
                current += n % 10;
                n = n / 10;
            }
            return current;
        }
        #endregion

        #region Max Sum Sub Array: Amazon #49
        public static int Max_Sum_Sub_Array(int[] input)
        {
            int currentMax = 0;
            int currentSoFar = 0;
            foreach (var num in input)
            {
                currentMax = Math.Max(num, currentMax + num);
                currentSoFar = Math.Max(currentMax, currentSoFar);
            }
            return currentSoFar;
        }

        #endregion

        public static string[] GetMovieRecommendations(TreeNode<MovieRating> movies, string movieName, int number)
        {
            Queue<TreeNode<MovieRating>> movieQueue = new Queue<TreeNode<MovieRating>>();
            Queue<TreeNode<MovieRating>> leftOverMovies = new Queue<TreeNode<MovieRating>>();
            List<string> output = new List<string>();
            movieQueue.Enqueue(movies);
            int num = GetMovieRecommendations(movieQueue, leftOverMovies, output, number);

            if (num > 0 && leftOverMovies.Count > 0) {
                GetMovieRecommendations(leftOverMovies, new Queue<TreeNode<MovieRating>>(), output, num);
            }


            return output.ToArray();
        }

        private static int GetMovieRecommendations(Queue<TreeNode<MovieRating>> movieQueue, Queue<TreeNode<MovieRating>> leftOverMovies, List<string> output, int number)
        {
            while (movieQueue.Count > 0 && number>0)
            {
                TreeNode<MovieRating> m = movieQueue.Dequeue();
                int leftRating = int.MinValue;
                int rightRating = int.MinValue;
                string leftMovie = "";
                string rightMovie = "";
                if (m.left != null)
                {
                    leftRating = m.left.val.Rating;
                    leftMovie = m.left.val.MovieName;
                    movieQueue.Enqueue(m.left);
                }
                    
                if (m.right != null)
                {
                    rightRating = m.right.val.Rating;
                    rightMovie = m.right.val.MovieName;
                    movieQueue.Enqueue(m.right);
                }
                

                if (leftRating > rightRating)
                {
                    output.Add(leftMovie);
                    leftOverMovies.Enqueue(m.right);
                }
                else
                {
                    output.Add(rightMovie);
                    leftOverMovies.Enqueue(m.left);
                }
                number--;
            }
            return number;
        }

        public static int GetThrowCount(string[] throws, int count) {
            List<int> prevScores = new List<int>();
            int score = 0;
            int lastScore;
            foreach (string c in throws) {
                int len = prevScores.Count;
                lastScore = prevScores.Count > 0 ? prevScores.ElementAt(len - 1) : 0;
                if (len == 0 && (c == "z" || c == "x" || c == "+")) {
                    return 0;
                }
                if (c == "z")
                {
                    score -= lastScore;
                    prevScores.RemoveAt(len - 1);
                }
                else if (c == "x")
                {
                    score += 2 * lastScore;
                    prevScores.Add(2 * lastScore);
                }
                else if (c == "+")
                {
                    score += lastScore + prevScores.ElementAt(len - 2);
                    prevScores.Add(lastScore + prevScores.ElementAt(len - 2));
                }
                else {
                    int currScore = Convert.ToInt32(c);
                    score += currScore;
                    prevScores.Add(currScore);
                }
            }
            return score;

        }

        public static int TotalScore(string[] blocks, int n)
        {
            // WRITE YOUR CODE HERE
            int sum = 0;
            int lastScore = 0;
            List<int> intScore = new List<int>();
            //List<int> scoreTracker = new List<int>();
            for (int i = 0; i < blocks.Length; i++)
            {
                bool isInt = int.TryParse(blocks[i], out n);
                if (isInt == true)
                {
                    sum += Convert.ToInt32(blocks[i]);
                    intScore.Add(Convert.ToInt32(blocks[i]));
                
                }
                else if (blocks[i] == "x")
                {
                    intScore.Add(intScore.Last() * 2);
                    sum += intScore.Last();
                }
                else if (blocks[i] == "z")
                {
                    sum -= intScore.Last();
                    intScore.RemoveAt(intScore.Count - 1);
                }
                else if (blocks[i] == "+")
                {
                    if (intScore.Count < 2)
                    {
                        lastScore = intScore.First() + intScore.Last();
                        intScore.Add(lastScore);
                    }
                    else
                    {
                        var intScoreArray = intScore.ToArray();
                        lastScore = intScoreArray[intScoreArray.Length - 1] +
                                    intScoreArray[intScoreArray.Length - 2];
                        intScore.Add(lastScore);

                    }
                    sum += lastScore;

                }
            }
            return sum;
        }
        //Tesla codility
        public static int InterestingCount(string S, string T)
        {
            int interestingCount = 0;
            DateTime fromTime = DateTime.Today.Add(TimeSpan.Parse(S));
            DateTime toTime = DateTime.Today.Add(TimeSpan.Parse(T));
            HashSet<char> updatedTime = new HashSet<char>();
            while (fromTime <= toTime) {
                string fTime = fromTime.ToString("HH:mm:ss");
                foreach (char s in fTime)
                {
                    if (s != ':' && !updatedTime.Contains(s))
                    {
                        updatedTime.Add(s);
                    }
                }
                if (updatedTime.Count <= 2)
                    interestingCount++;
                fromTime = fromTime.AddSeconds(1);
                updatedTime.Clear();
            }
            return interestingCount;
        }

        //tesla
        public static int Steps(string S)
        {
            int steps = 0;
            int num = Convert.ToInt32(S,2);

            while (num > 0) {
                if (num % 2 == 0)
                    num = num / 2;
                else
                    num--;
                steps++;
            }

            return steps;
        }

        //tesla
        public static int solution(string S)
        {
            int cyclic = 1;
            int totalRotations = 1;
            char[] inputString = S.ToCharArray();
            char[] cyclicArr = S.ToCharArray();
            int hc = S.GetHashCode();
            while (totalRotations < S.Length) {
                Rotate(cyclicArr, 1);
                int hc1 = string.Join("", cyclicArr).GetHashCode();
                var t = string.Join("", cyclicArr);
                //if (S.Equals(new string(cyclicArr)))
                //if (S.Equals(t))
                if(hc == hc1)
                    cyclic++;
                totalRotations++;
            }
            return cyclic;
        }

        private static void Rotate(char[] arr, int d)
        {
            int n = arr.Length;
            //Reverse(arr, 0, d - 1);
            Reverse(arr, d, n - 1);
            Reverse(arr, 0, n - 1);
        }

        private static void Reverse(char[] arr, int start,int end)
        {
            char temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> outList = new List<int>();
            while(left <= right)
            {
                if (IsSelfDividingNumber(left))
                    outList.Add(left);
                left++;
            }
            return outList;
        }

        public static bool IsSelfDividingNumber(int number) {
            int temp = number;
            while (temp != 0)
            {
                int reminder = temp % 10;
                if (reminder == 0 || number % reminder != 0)
                {
                    return false;
                }
                temp = temp / 10;
            }
            return true;
        }

        public static int maxArea(int[] height)
        {
            int maxarea = 0,l = 0,r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }

        //GoFundMe
        public static int FindMaxProduct(int[] input)
        {
            List<int> sortedInput = input.OrderBy(e => e).ToList();
            int product = 1;
            int count = 3;
            int maxProduct = sortedInput.ElementAt(0) * sortedInput.ElementAt(1) * sortedInput.ElementAt(sortedInput.Count - 1);
            for (int i = sortedInput.Count - 1; i > 0 && count > 0; i--)
            {
                product = product * sortedInput.ElementAt(i);
                count--;
            }
            return Math.Max(maxProduct, product);
        }
    }

}
    

    public class StackImpl
    {
        public int Max { get; private set; }
        public LinkedList<int> Node;
        public int Data;
        public StackImpl()
        {
            Node = new LinkedList<int>();
            Max = int.MinValue;
        }

        public void Push(int data)
        {
            Node.AddFirst(data);
            Max = Math.Max(Max, data);
        }

        public int Pop()
        {
            int ret = Node.First();
            Node.RemoveFirst();
            Max = Node.Max();
            return ret;
        }

    }

    public class ConstructMovieRatingTree
    {
        public TreeNode<MovieRating> Node { get; set; }
        public ConstructMovieRatingTree(MovieRating movie)
        {
            Node = new TreeNode<MovieRating>(movie);
        }
    }

}
