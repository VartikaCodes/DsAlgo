public class Solution
{
    public int MaxConsecutiveAnswers(string answerKey, int k)
    {
        // Return the max. consecutive occurrences of either 'T' or 'F'
        return Math.Max(Window(answerKey, k, 'T'), Window(answerKey, k, 'F'));
    }

    public int Window(string key, int k, char ans)
    {
        int j = 0; // start of the first window
        for (int i = 0; i < key.Length; i++)
        {
            /* If item does not match the current selected char
             * 1. Flip it, to make it part of the current window
             * 2. Decrease the number of flips available
            */
            if (key[i] != ans)
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
                if (key[j++] != ans)
                {
                    k++;
                }
            }

        }

        /* Return the length of the string minus the start of the largest window.
         * This will be the max. length of the consecutive occurances of that char.
        */
        return key.Length - j;
    }
}