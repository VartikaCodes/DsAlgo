public class Solution
{
    public bool CanFinish(int numCourses, int[][] pre)
    {
        var indegree = new int[numCourses];

        // Find the indegree of all the tasks
        for (int i = 0; i < pre.Length; i++)
        {
            var n1 = pre[i][0];
            indegree[n1]++;
        }

        /* Put all the tasks with indegree 0 into the queue
         * As those do not have any dependency.
         */
        var q = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
            {
                q.Enqueue(i);
            }
        }

        /* Dequeue each task from the Queue, and consider it as done.
         * Hence all the dependent tasks, can reduce their indegree by 1.
         * For each task, whose indegree becomes 0 (no dependencies), add it to the queue.
         */
        var count = 0;
        while (q.Count != 0)
        {
            var curr = q.Dequeue();
            count++;

            var i = 0;
            for (; i < pre.Length; i++)
            {
                if (pre[i][1] == curr)
                {
                    var n1 = pre[i][0];
                    indegree[n1]--;
                    if (indegree[n1] == 0)
                    {
                        q.Enqueue(n1);
                    }
                }
            }
        }

        // If all the tasks could be completed, return true, otherwise return false
        return count == numCourses;
    }
}