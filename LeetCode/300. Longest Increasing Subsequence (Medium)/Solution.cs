public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var n = nums.Length;
        var tail = new int[n];
        tail[0] = nums[0];
        var len = 0;

        for (int i = 1; i < n; i++)
        {
            if (tail[len] < nums[i])
            {
                tail[++len] = nums[i];
            }
            else
            {
                var ceil = FindCeiling(tail, 0, len, nums[i]);
                tail[ceil] = nums[i];
            }
        }

        return len + 1;
    }

    public int FindCeiling(int[] tail, int l, int h, int x)
    {
        var res = h;
        while (l <= h)
        {
            var m = l + (h - l) / 2;
            if (tail[m] == x)
            {
                return m;
            }
            else if (tail[m] < x)
            {
                l = m + 1;
            }
            else
            {
                h = m - 1;
                res = m;
            }
        }

        return res;
    }
}