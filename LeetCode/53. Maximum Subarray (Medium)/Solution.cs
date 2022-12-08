public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        var res = nums[0];
        var maxSum = nums[0];
        var n = nums.Length;

        for (int i = 1; i < n; i++)
        {
            var sum = maxSum + nums[i];
            maxSum = Math.Max(sum, nums[i]);
            res = Math.Max(res, maxSum);
        }

        return res;
    }
}