public class Solution
{
    public bool IsPalindrome(string s)
    {
        var res = CurateString(s);
        var n = res.Length;

        if (n == 0)
        {
            return true;
        }

        /* Two pointers l and h, compare the left and right ends of the string.
         * In case the char at l and h, do not match, immediately return false, as string cannot be palindrome.
         * Else, return true, after the entire string parses successfully.
         */
        var l = 0;
        var h = n - 1;

        while (l < h)
        {
            if (res[l] != res[h])
            {
                return false;
            }

            l++;
            h--;
        }

        return true;
    }

    /* Converts the string to lowercase, 
     * and returns a new string with only valid characters.
     */
    public string CurateString(string s)
    {
        s = s.ToLower();
        var res = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= 'a' && s[i] <= 'z' || s[i] >= '0' && s[i] <= '9')
            {
                res += s[i];
            }
        }

        return res;
    }
}