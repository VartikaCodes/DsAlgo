public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;

        var n = prices.Length;
        if (n <= 1)
        {
            return maxProfit;
        }

        var min = prices[0];
        for (int i = 1; i < n; i++)
        {
            maxProfit = Math.Max(maxProfit, prices[i] - min);
            min = Math.Min(min, prices[i]);
        }

        return maxProfit;
    }
}