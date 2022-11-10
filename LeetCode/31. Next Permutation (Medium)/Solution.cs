public class Solution
{
    public void NextPermutation(int[] nums)
    {
        /* Find the first decreasing number
         * And save its index in i
         */
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }

        /* Find the number just greater than the first decreasing number
         * Add save its index in j
         */
        if (i >= 0)
        {
            int j = nums.Length - 1;
            while (nums[j] <= nums[i])
            {
                j--;
            }

            // Swap the 2 elements found at index i & j
            Swap(nums, i, j);
        }

        /* Reverse the rest of the numbers, from the i+1th index onwards.
         * This gives the next greater number.
         */
        Reverse(nums, i + 1);
    }

    private void Reverse(int[] nums, int start)
    {
        int i = start, j = nums.Length - 1;
        while (i < j)
        {
            Swap(nums, i, j);
            i++;
            j--;
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}