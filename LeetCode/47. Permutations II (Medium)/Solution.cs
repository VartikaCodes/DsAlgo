public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var res = new List<IList<int>>();

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
        Backtrack(comb, nums.Length, counter, res);

        return res;
    }

    protected void Backtrack(
            LinkedList<int> comb,
            int n,
            Dictionary<int, int> counter,
            List<IList<int>> res)
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

            // add this number into the current combination
            comb.AddLast(num);
            counter[num]--;

            // continue the exploration
            Backtrack(comb, n, counter, res);

            // revert the choice for the next exploration
            comb.RemoveLast();
            counter[num] = count;
        }
    }
}