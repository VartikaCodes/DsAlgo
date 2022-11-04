public class Solution
{
    public bool IsNumber(string s)
    {
        var seenDigit = false;
        var seenExponent = false;
        var seenDot = false;
        var n = s.Length;


        for (int i = 0; i < n; i++)
        {
            // If the char is a digit, set seenDigit to true
            if (char.IsDigit(s[i]))
            {
                seenDigit = true;
            }
            /* If the char is a sign
             * Check if it is the first char in string
             * Or it is immediately after exponent symbol
             * Otherwise return false
             */
            else if (s[i] == '+' || s[i] == '-')
            {
                if (i > 0 && (s[i - 1] != 'e' && s[i - 1] != 'E'))
                {
                    return false;
                }
            }
            /* If the char is an exponent
             * Check if a digit is seen
             * And an exponent symbol is not seen already
             * Otherwise return false;
             */
            else if (s[i] == 'e' || s[i] == 'E')
            {
                if (!seenDigit || seenExponent)
                {
                    return false;
                }

                seenExponent = true;
                seenDigit = false; // Set seenDigit to false, as after exponent,
                                   // again digits need to be seen, for string to be valid
            } 
            /* If char is a dot
             * Check if a dot and exponent are not already seen
             * Otherwise return false;
             */
            else if (s[i] == '.')
            {
                if (seenDot || seenExponent)
                {
                    return false;
                }

                seenDot = true;
            }
            // For any other characters, return false
            else
            {
                return false;
            }
        }

        // Return seenDigit, to ensure a string is valid only
        // If there are digits after the exponent symbol
        return seenDigit;
    }
}