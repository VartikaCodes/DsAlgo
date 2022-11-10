public class Solution
{
    public int NumSquarefulPerms(int[] nums)
    {
        var res = new List<IList<int>>();
        var n = nums.Length;

        // count the occurrence of each number
        var counter = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!counter.ContainsKey(num))
            {
                counter.Add(num, 0);
            }

            counter[num]++;
        }

        var comb = new LinkedList<int>();
        PermuteRec(comb, n, counter, res);

        return res.Count;
    }

    /* Rejects cases where the resultant permuatations
     * will not have adjacent digits as perfect square.
     * Hence cuts on some expensive recursive calls
     */
    public bool IsSafe(LinkedList<int> comb, int num)
    {
        if (comb.Count != 0)
        {
            var last = comb.Last.Value;
            var sum = last + num;

            return IsPerfectSquare(sum);
        }

        return true;
    }

    /* Returns true if number has no decimal point.
     * This will be true only for perfect Squares
     */
    public bool IsPerfectSquare(int num)
    {
        double srt = Math.Sqrt(num);
        return srt % 1 == 0;
    }

    public void PermuteRec(LinkedList<int> comb, int n, Dictionary<int, int> counter, List<IList<int>> res)
    {
        if (comb.Count == n)
        {
            // make a deep copy of the resulting permutation,
            // since the permutation would be backtracked later.
            res.Add(new List<int>(comb));
            return;
        }

        foreach (var entry in counter)
        {
            var num = entry.Key;
            var count = entry.Value;

            if (count == 0)
            {
                continue;
            }

            if (IsSafe(comb, num))
            {
                // add this number into the current combination
                comb.AddLast(num);
                counter[num]--;

                // continue the exploration
                PermuteRec(comb, n, counter, res);

                // revert the choice for the next exploration
                comb.RemoveLast();
                counter[num] = count;
            }

        }
    }
}