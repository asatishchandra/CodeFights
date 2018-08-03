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
            //var sumExists = Google.IsSumPossibleRetIndices(new int[] {10, 15, 3, 7 }, 17);
            //var productArray = Uber.FindProductNoDivision(new int[] { 3, 2, 1 });

            /*TreeNode tree = new TreeNode(10);
            tree.left = new TreeNode(5);
            tree.right = new TreeNode(-3);
            tree.left.left = new TreeNode(3);
            tree.left.right = new TreeNode(2);
            tree.right.right = new TreeNode(11);
            tree.left.left.left = new TreeNode(3);
            tree.left.left.right = new TreeNode(-2);
            tree.left.right.right = new TreeNode(1);
            Google.Serialize(tree);*/

            Stripe.FirstMissingPositive(new int[] { 3,4,-1,1});
        }
    }
}
