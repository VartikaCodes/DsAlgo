public class TreeNode
{
     public int val;
     public TreeNode left;
     public TreeNode right;

     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    {
         this.val = val;
         this.left = left;
         this.right = right;
     }
}

public class Solution
{
    public int Sum = 0; // Stores the sum of all roottro leaf sums.

    public int SumNumbers(TreeNode root)
    {
        SumRec(root, 0);
        return Sum;
    }

    // Preorder Traversal
    public void SumRec(TreeNode root, int currSum)
    {
        if (root != null)
        {
            currSum = currSum * 10 + root.val;

            // If Leaf Node, add the curr sum to overall root to leaf sum
            if (root.left == null && root.right == null)
            {
                Sum += currSum;
            }

            SumRec(root.left, currSum);
            SumRec(root.right, currSum);
        }
    }
}