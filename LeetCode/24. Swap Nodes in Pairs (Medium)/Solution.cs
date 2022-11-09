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
 
public class Solution
{
    public ListNode SwapPairs(ListNode head)
    {
        /*If list has no nodes, or only 1 node
         * Return thr head as is
         */
        if (head == null || head.next == null)
        {
            return head;
        }

        var prev = head;
        var curr = head.next;
        var next_head = head.next; // To store the new head of the Linked List

        while (prev != null && curr != null)
        {
            var next = curr.next;
            curr.next = prev;

            /* If 2 nodes are present, swap
             * Else do not swap, just link prev node to the next node
             */
            if (next != null && next.next != null)
            {
                prev.next = next.next;
                prev = next;
                curr = next.next;
            }
            else
            {
                prev.next = next;
                prev = next;
                curr = next;
            }
        }

        return next_head;
    }
}