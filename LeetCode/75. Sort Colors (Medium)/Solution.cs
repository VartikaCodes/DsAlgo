public class Solution
{
    public void SortColors(int[] nums)
    {
        var low = 0;
        var mid = 0;
        var high = nums.Length - 1;

        while (mid <= high)
        {
            /* In case the color is 0
             * Move it to the first part of the array.
             * Increment low to set new boundary for first part of array
             * Increment mid, to look at the next item
             */
            if (nums[mid] == 0)
            {
                var temp = nums[low];
                nums[low] = nums[mid];
                nums[mid] = temp;

                low++;
                mid++;
            }
            /* In case the color is 1
             * It is already in the mid part of second helf of the array
             * Increment mid, to look at the next item
             */
            else if (nums[mid] == 1)
            {
                mid++;
            }
            /* In case the color is 2
             * Move it to the last half part of the array.
             * Decrement high to set new boundary for last part of array
             * Do no change mid, as it already pointing to new item, after swap.
             */
            else
            {
                var temp = nums[mid];
                nums[mid] = nums[high];
                nums[high] = temp;

                high--;
            }
        }
    }
}