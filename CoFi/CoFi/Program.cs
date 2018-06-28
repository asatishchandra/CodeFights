using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoFi
{
    class Program
    {
        static void Main(string[] args)
        {
            //reverseParentheses("The ((quick (brown) (fox) jumps over the lazy) dog)");
            //var a = new int[] { 2, 1, 2, 1, 1, 1, 2 };
            //var b = new int[] { 1, 1, 2, 1, 2, 1, 2 };
            //areSimilar(a, b);
            //var b = new int[] { 2, 4, 3, 5, 1 };
            //firstDuplicate(b);
            //firstNotRepeatingCharacter("abacabad");
            /*var grid = new char[9][];
            grid[0] = new char[] { '.', '.', '.', '1', '4', '.', '.', '2', '.' };
            grid[1] = new char[] { '.', '.', '6', '.', '.', '.', '.', '.', '.' };
            grid[2] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            grid[3] = new char[] { '.', '.', '1', '.', '.', '.', '.', '.', '.'};
            grid[4] = new char[] { '.', '6', '7', '.', '.', '.', '.', '.', '9' };
            grid[5] = new char[] { '.', '.', '.', '.', '.', '.', '8', '1', '.' };
            grid[6] = new char[] { '.', '3', '.', '.', '.', '.', '.', '.', '6' };
            grid[7] = new char[] { '.', '.', '.', '.', '.', '7', '.', '.', '.' };
            grid[8] = new char[] { '.', '.', '.', '5', '.', '.', '.', '7', '.' };*/
            //sudoku2(grid);
            //palindromeRearranging("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaabc");
            //almost_palindromes("abcdcaa");
            //var arr = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            //doSearch(arr, 73);

            //var crypt = new string[] { "A","A","A" };
            //var solution = new char[1][];
            //solution[0] = new char[] { 'A', '0' };
            /*solution[1] = new char[] { 'M', '1' };
            solution[2] = new char[] { 'Y', '2' };
            solution[3] = new char[] { 'E', '5' };
            solution[4] = new char[] { 'N', '6' };
            solution[5] = new char[] { 'D', '7' };
            solution[6] = new char[] { 'R', '8' };
            solution[7] = new char[] { 'S', '9' };*/
            //isCryptSolution(crypt, solution);

            /*var t = new ListNode<int>();
            t.value = 3;
            t.next = new ListNode<int>();
            t.next.value = 1;
            t.next.next = new ListNode<int>();
            t.next.next.value = 2;
            t.next.next.next = new ListNode<int>();
            t.next.next.next.value = 3;
            t.next.next.next.next = new ListNode<int>();
            t.next.next.next.next.value = 4;
            t.next.next.next.next.next = new ListNode<int>();
            t.next.next.next.next.next.value = 5;
            removeKFromList(t, 3);*/

            //RevereseNumberInPlace(1234);

            /*var t = new ListNode<int>();
            t.value = 9876;
            t.next = new ListNode<int>();
            t.next.value = 5432;
            t.next.next = new ListNode<int>();
            t.next.next.value = 1999;

            var t2 = new ListNode<int>();
            t2.value = 1;
            t2.next = new ListNode<int>();
            t2.next.value = 8001;*/
            //addTwoHugeNumbers(t, t2);

            /*var t = new ListNode<int>();
            t.value = 1;
            t.next = new ListNode<int>();
            t.next.value = 1;
            t.next.next = new ListNode<int>();
            t.next.next.value = 2;
            t.next.next.next = new ListNode<int>();
            t.next.next.next.value = 4;

            var t2 = new ListNode<int>();
            t2.value = 0;
            t2.next = new ListNode<int>();
            t2.next.value = 3;
            t2.next.next = new ListNode<int>();
            t2.next.next.value = 5;
            mergeTwoLinkedLists(t, t2);*/

            /*var t = new ListNode<int>();
            t.value = 1;
            t.next = new ListNode<int>();
            t.next.value = 2;
            t.next.next = new ListNode<int>();
            t.next.next.value = 3;
            t.next.next.next = new ListNode<int>();
            t.next.next.next.value = 4;
            t.next.next.next.next = new ListNode<int>();
            t.next.next.next.next.value = 5;*/
            //reverseNodesInKGroups(t, 2);

            //rearrangeLastN(t, 3);

            //areEquallyStrong(10, 15,10,16);

            //var a = new int[] { 2,4,1,0 };
            //arrayMaximalAdjacentDifference(a);

            //isIPv4Address("172.316.254.1");

            /*int tsmCount = 3;
            string[] availableLocations = new string[] { "SF", "NY", "Seattle" };
            int minExperience = 3;
            string[] jobApplications = new string[] { "JohnSmith 4 NY",
                   "John 2 NY",
                   "Frank 4 SF",
                   "Katy 3 SF",
                   "Michael 3 Washington",
                   "Tom 10 SF" };
            assignJobApplications(tsmCount, availableLocations, minExperience, jobApplications);*/

            var input = new int[] { 5, 3, 6, 9, 10 };
            avoidObstacles(input);

        }

        static string reverseString(string s)
        {
            char[] try1 = s.ToCharArray();
            string r = "";
            for (int i = try1.Length - 1; i >= 0; i--)
                r += try1[i].ToString();

            return r;
        }

        static string reverseParentheses(string s)
        {
            int begin = 0;
            int end = s.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
                if (s[i].Equals('('))
                    begin = i;
                if (s[i].Equals(')'))
                {
                    end = i;
                    string temp = s.Substring(begin + 1, end - begin - 1);
                    return reverseParentheses(s.Substring(0, begin) + temp.Reverse() + s.Substring(end + 1));
                }
            }
            return s;
        }
        static bool areSimilar(int[] a, int[] b)
        {
            var foundDiff = 0;
            if (a.Length != b.Length)
                return false;
            for (var i = 0; i < a.Length; i++)
            {
                if (Array.IndexOf(b, a[i]) == -1)
                    return false;
                if (foundDiff > 1)
                    return false;
                if (a[i] == b[i])
                    continue;
                for (var j = 0; j < b.Length; j++)
                {
                    if (foundDiff >= 1)
                        return false;
                    if (a[i] == b[j] && a[j] != b[j])
                    {
                        foundDiff++;
                        var temp = b[i];
                        b[i] = b[j];
                        b[j] = temp;
                        break;
                    }
                }
            }
            Console.WriteLine(foundDiff > 1 ? false : true);
            return foundDiff > 1 ? false : true;
        }

        static int firstDuplicate(int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                var position = Math.Abs(a[i]) - 1;
                if (a[position] < 0) return Math.Abs(a[i]);
                a[position] = -a[position];
            }
            return -1;
        }

        static char firstNotRepeatingCharacter(string s)
        {
            var t = s.GroupBy(e => e).Where(e => e.Count() == 1).Select(e => e.Key).FirstOrDefault();
            return !char.IsLetter(t) ? '_' : t;
        }

        static bool palindromeRearranging(string inputString)
        {
            //var countList = new List<int>();
            var t = inputString.GroupBy(e => e).Where(e => e.Count() % 2 == 1).Count() <= 1;
            return t;
        }

        static int almost_palindromes(string str)
        {
            var count = 0;
            var j = str.Length - 1;
            for (var i = 0; i < str.Length; i++)
            {
                if (i == j)
                    break;
                if (str[i] != str[j])
                    count += 2;
                j--;
            }
            return count;
        }

        public static int doSearch(int[] array, int targetValue)
        {
            int min = 0;
            //System.out.println(Arrays.toString(array));
            int max = array.Length - 1;
            int guess;

            while (max >= min)
            {
                //int avg = (min + max) / 2;
                guess = (min + max) / 2;
                if (array[guess] == targetValue)
                    return guess;
                if (targetValue > array[guess])
                    min = guess + 1;
                else
                    max = guess - 1;
            }
            return -1;
        }
        public static bool isCryptSolution(string[] crypt, char[][] solution)
        {
            var sumStr = new List<string>();
            var set = new Dictionary<char, char>();
            for (var i = 0; i < solution.Length; i++)
            {
                set[solution[i][0]] = solution[i][1];
            }



            foreach (var str in crypt)
            {
                if (str.Length != 1 && set[str[0]] == '0') return false;
                var strBuilder = new StringBuilder();
                for (var k = 0; k < str.Length; k++)
                {
                    strBuilder.Append(set[str[k]]);
                }
                sumStr.Add(strBuilder.ToString());
            }
            return Convert.ToInt64(sumStr.ElementAt(0)) + Convert.ToInt64(sumStr.ElementAt(1)) == Convert.ToInt64(sumStr.ElementAt(2));
        }



        public static ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            ListNode<int> x = l;
            ListNode<int> prev = null;
            while (x != null)
            {
                ListNode<int> x_next = x.next;
                if (x.value == k)
                {
                    if (prev != null)
                    {
                        prev.next = x_next;
                    }
                    else
                    {
                        l = x_next;
                    }
                }
                else
                {
                    prev = x;
                }
                x = x_next;
            }

            return l;
        }

        public static int RevereseNumberInPlace(int number)
        {
            int rev = 0;

            while (number != 0)
            {
                rev = (rev * 10) + (number % 10);
                number = number / 10;

            }
            return rev;
        }

        static ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b)
        {
            int countA = 0, countB = 0;
            //reverse list a 
            var curr = a;
            ListNode<int> prev = null;
            while (curr != null)
            {
                countA++;
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            //prev is now new root!
            a = prev; //now it is reversed

            //reverse list b
            curr = b;
            prev = null;
            while (curr != null)
            {
                countB++;
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            b = prev; //now it is reversed


            var stepA = a;
            var stepB = b;

            ListNode<int> result = (countA >= countB) ? a : b;
            curr = result;


            int carryOver = 0;


            while (result != null)
            {
                int aValue = (stepA == null) ? 0 : stepA.value;
                int bValue = (stepB == null) ? 0 : stepB.value;

                int tot = aValue + bValue + carryOver;

                if (tot / 10000 > 0)
                {
                    carryOver = 1;
                    tot = tot % 10000;
                }
                else
                {
                    carryOver = 0;
                }
                if (stepA != null) stepA = stepA.next;
                if (stepB != null) stepB = stepB.next;

                result.value = tot;
                if (result.next == null && carryOver == 1)
                {
                    var n = new ListNode<int>();
                    n.value = 1;
                    result.next = n;
                    result = result.next.next;

                }
                else
                    result = result.next;

            }
            prev = null;
            while (curr != null)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            result = prev; //now it is reversed

            return result;

        }

        static ListNode<int> mergeTwoLinkedLists(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.value < l2.value)
            {
                l1.next = mergeTwoLinkedLists(l1.next, l2);
                return l1;
            }

            else
            {
                l2.next = mergeTwoLinkedLists(l1, l2.next);
                return l2;
            }
        }

        static ListNode<int> reverseNodesInKGroups(ListNode<int> l, int k)
        {
            if (k == 1)
                return l;
            int len = 0;
            ListNode<int> curr = l;
            ListNode<int> prev = null;
            ListNode<int> retList = null;
            ListNode<int> t = null;

            while (curr != null)
            {
                len++;
                curr = curr.next;
            }
            curr = l;

            if (len > k)
            {
                while (len >= 0 && len >= k)
                {
                    var swaps = k;
                    prev = null;
                    while (swaps > 0)
                    {
                        var temp = curr.next;
                        curr.next = prev;
                        prev = curr;
                        curr = temp;
                        swaps--;
                    }
                    if (retList == null)
                        retList = prev;
                    else
                    {
                        t = retList;
                        while (t.next != null)
                        {
                            t = t.next;
                        }
                        t.next = prev;
                    }
                    len = len - k;
                }
            }
            else
            {
                prev = null;
                while (k >= 0)
                {
                    var temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                    k--;
                }
                retList = prev;
            }
            if (len > 0 && curr != null)
            {
                t = retList;
                while (t.next != null)
                {
                    t = t.next;
                }
                t.next = curr;
            }
            return retList;
        }

        static ListNode<int> rearrangeLastN(ListNode<int> l, int n)
        {
            var current = l;
            if (n == 0) return l;
            for (int i = 0; i < n; i++)
            {
                if (current == null) return l;
                current = current.next;
            }
            if (current == null) return l;
            var head = l;
            while (current.next != null)
            {
                current = current.next;
                head = head.next;
            }
            var result = head.next;
            head.next = null;
            current.next = l;
            return result;

        }

        static bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            return (yourRight == friendsRight && yourLeft == friendsLeft) || (yourRight == friendsLeft && yourLeft == friendsRight);
        }

        static int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            var maxDif = int.MinValue;
            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                maxDif = Math.Max(maxDif, Math.Abs(inputArray[i] - inputArray[i + 1]));
            }
            return maxDif;
        }

        static bool isIPv4Address(string inputString)
        {
            var num = 0;
            var ipArr = inputString.Split('.');
            if (ipArr.Length != 4) return false;
            foreach (var ele in ipArr)
            {
                if (!int.TryParse(ele, out num))
                    return false;
                if (num < 0 || num > 255)
                    return false;
            }
            return true;
        }

        static int[] assignJobApplications(int tsmCount, string[] availableLocations, int minExperience, string[] jobApplications)
        {
            List<int> retList = new List<int>();
            int count = 0;
            var appArr = new List<string>();
            foreach (var app in jobApplications)
            {
                if (appArr.Count > 0) appArr.RemoveRange(0, 3);
                appArr.AddRange(app.Split(' ').ToList());
                if (Convert.ToInt32(appArr[1]) < minExperience || !availableLocations.Contains(appArr[2]))
                    retList.Add(-1);
                else
                {
                    if (count == tsmCount)
                        count = 0;
                    count++;
                    retList.Add(count);
                }

            }

            return retList.ToArray();
        }

        static int avoidObstacles(int[] inputArray)
        {
            int count = 2;
            var ableToJump = false;
            while (!ableToJump)
            {
                foreach (int val in inputArray)
                {
                    if (val == count || val % count == 0)
                    {
                        count++;
                        ableToJump = false;
                        break;
                    }
                    else
                    {
                        ableToJump = true;
                    }
                }
            }
            return count;
        }
    }
    public class ListNode<T>
    {
        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }
}
