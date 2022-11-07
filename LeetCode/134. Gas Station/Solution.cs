public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var prevGas = 0; // Saves any gas liability in previous circuit.
        var currGas = gas[0]; // Save the first gas as initial gas.
        var start = 0; // Start index of the circuit
        var n = gas.Length;

        for (int i = 1; i < n; i++)
        {
            // Subtract the cost of travelling to next gas station from current gas
            currGas -= cost[i - 1];

            /* If the curr gas is negative, 
             * then this gas station cannot be the starting point
             * Do, Select the curr gas station as starting point
             * Save the curr liability as prev gas
             * Start with the curr gas as 0
             */
            if (currGas < 0)
            {
                start = i;
                prevGas += currGas;
                currGas = 0;
            }

            // Fill tank with gas from curr gas station
            currGas += gas[i];
        }

        /* Add any gas liability to the curr gas
         * and subtract cost of completing the circuit
         */
        currGas += prevGas - cost[n - 1];

        /* Return -1, if curr gas is negative, 
         * else return the index of the gas station to start from
         */
        return currGas < 0 ? -1 : start;
    }
}