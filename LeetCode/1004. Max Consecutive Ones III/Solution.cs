public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        var ans = 1; // Expected Value
        var j = 0; // Start of First Window

        for (int i = 0; i < nums.Length; i++)
        {
            /*If item does not match the expected value
             * 1.Flip it, to make it part of the current window
             *2.Decrease the number of flips available
             */
            if (nums[i] != ans)
            {
                k--;
            }

            // If no more flips available, slide the window.
            if (k < 0)
            {
                /* If the item that required a flip, is slided over
                 * and is not part of the current window, anymore
                 * reset the flip count.
                */
                if (nums[j++] != ans)
                {
                    k++;
                }
            }
        }

        /* Return the length of the array minus the start of the largest window.
         * This will be the max. length of the consecutive occurances of that char.
        */
        return nums.Length - j;
    }
}