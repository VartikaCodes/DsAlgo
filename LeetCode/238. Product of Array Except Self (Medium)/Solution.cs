public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var n = nums.Length;
        var answer = new int[n];
        answer[0] = 1;

        for (int i = 1; i < n; i++)
        {
            answer[i] = answer[i - 1] * nums[i - 1];
        }

        var right = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            right *= nums[i + 1];
            answer[i] *= right;
        }

        return answer;
    }
}