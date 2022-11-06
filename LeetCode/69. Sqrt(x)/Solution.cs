public class Solution
{
    public int MySqrt(int x)
    {
        // Square root for the numbers < 2, is the number itself
        if (x < 2)
        {
            return x;
        }

        // Sq root for any no, is never greater than half of that number
        var l = 2;
        var h = x / 2;

        while (l <= h)
        {
            var mid = l + (h - l) / 2;
            long midSq = (long)mid * mid;

            // Return mid, if it is the Sq root
            if (midSq == x)
            {
                return mid;
            }
            // If Sq root is greater than x
            else if (midSq > x)
            {
                h = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return h;
    }
}