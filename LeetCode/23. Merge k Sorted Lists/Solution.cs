public class ListNode 
{
    public int val;
    public ListNode next;

    public ListNode(int val=0, ListNode next=null) 
    {
        this.val = val;
        this.next = next;
    }
}

// Custom Heap Data Structure
public class PriorityQueue
{
    public ListNode[] arr;
    public int cap;
    public int size;

    public PriorityQueue(int c)
    {
        cap = c;
        arr = new ListNode[c];
        size = 0;
    }

    public int Left(int i)
    {
        return 2 * i + 1;
    }

    public int Right(int i)
    {
        return 2 * i + 2;
    }

    public int Parent(int i)
    {
        return (i - 1) / 2;
    }

    public int Count()
    {
        return size;
    }

    /* Compare the node with its left and right child
     * If greater, swap with the smallest child, and 
     * Then recursivelt heapify the smallest.
     */
    public void Heapify(int i)
    {
        var lt = Left(i);
        var rt = Right(i);
        var smallest = i;

        if (lt < size && arr[lt].val < arr[smallest].val)
        {
            smallest = lt;
        }
        if (rt < size && arr[rt].val < arr[smallest].val)
        {
            smallest = rt;
        }

        if (smallest != i)
        {
            var temp = arr[smallest];
            arr[smallest] = arr[i];
            arr[i] = temp;

            Heapify(smallest);
        }
    }

    /* Add a new node at the end of the heap
     * Compare with Parent and if found to be smaller,
     * Exchange with parent node and recusively call for next parent
     */
    public void Enqueue(ListNode x)
    {
        if (size == cap)
        {
            return;
        }

        arr[size++] = x;
        for (int i = size - 1; i >= 0 && arr[Parent(i)].val > arr[i].val;)
        {
            var temp = arr[i];
            arr[i] = arr[Parent(i)];
            arr[Parent(i)] = temp;

            i = Parent(i);
        }
    }

    /* Remove a node from the root, as it is the smallest in all lists
     * Swap this node with the last node, and heapify the new root
     * Reduce the size of the heap, to move the removed node, out of scope
     */
    public ListNode Dequeue()
    {
        if (size <= 0)
        {
            return null;
        }
        if (size == 1)
        {
            size--;
            return arr[size];
        }

        var temp = arr[0];
        arr[0] = arr[size - 1];
        arr[size - 1] = temp;

        size--;
        Heapify(0);
        return arr[size];
    }
}

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var k = lists.Length;
        ListNode res = null;

        // If no items in input list, return null
        if (k == 0)
        {
            return res;
        }

        var pq = new PriorityQueue(k);

        // Enqueue the first item of each list into the heap
        for (int i = 0; i < k; i++)
        {
            if (lists[i] != null)
            {
                pq.Enqueue(lists[i]);
            }
        }

        /* If there is atleast one item in the heap
         * Then dequeue the top element and initialise the result with it.
         */
        if (pq.Count() != 0)
        {
            var curr = pq.Dequeue();
            res = curr;

            curr = curr.next;
            if (curr != null)
            {
                pq.Enqueue(curr);
            }
        }

        /* While there are items in heap, dequeue one by one
         * And add them to the result
         * If that list has any next items, enqueue it into the heap.
         */
        var temp = res;
        while (pq.Count() != 0)
        {
            var curr = pq.Dequeue();
            temp.next = curr;
            temp = curr;

            if (curr.next != null)
            {
                pq.Enqueue(curr.next);
            }
        }

        // Return the head of resultant ListNode
        return res;
    }
}