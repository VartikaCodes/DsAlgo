/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return node;
        }

        /* Hash map to save the visited node and it's respective clone
         * as key and value respectively. This helps to avoid cycles.
         */
        var visited = new Dictionary<Node, Node>();

        // Put the first node in the queue
        var q = new Queue<Node>();
        q.Enqueue(node);

        // Clone the node and put it in the visited dictionary.
        visited.Add(node, new Node(node.val, new List<Node>()));

        // Start BFS traversal
        while (q.Count != 0)
        {
            // Pop a node say "n" from the from the front of the queue.
            Node n = q.Dequeue();

            // Iterate through all the neighbors of the node "n"
            foreach (var neighbor in n.neighbors)
            {
                if (!visited.ContainsKey(neighbor))
                {
                    // Clone the neighbor and put in the visited, if not present already
                    visited.Add(neighbor, new Node(neighbor.val, new List<Node>()));

                    // Add the newly encountered node to the queue.
                    q.Enqueue(neighbor);
                }

                // Add the clone of the neighbor to the neighbors of the clone node "n".
                visited[n].neighbors.Add(visited[neighbor]);
            }
        }

        // Return the clone of the node from visited.
        return visited[node];
    }
}