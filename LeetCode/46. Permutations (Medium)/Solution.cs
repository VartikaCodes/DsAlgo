public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var res = new List<IList<int>>();
        var n = nums.Length;

        PermuteRec(nums, 0, n - 1, res);

        return res;
    }

    public void PermuteRec(int[] nums, int l, int h, List<IList<int>> res)
    {
        // Once all the swapping is done, add the permutation to result
        if (l == h)
        {
            res.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                res[res.Count - 1].Add(nums[i]);
            }

            return;
        }

        for (int i = l; i <= h; i++)
        {
            // Swap(nums[l], nums[i]) to get next permutation
            var temp1 = nums[l];
            nums[l] = nums[i];
            nums[i] = temp1;

            // Permute for the next digit
            PermuteRec(nums, l + 1, h, res);

            /* Swap(nums[i], nums[l]) to reinstate the original array
             * Backtrack, so that next permutation can be got
             */
            var temp2 = nums[l];
            nums[l] = nums[i];
            nums[i] = temp2;
        }
    }
}