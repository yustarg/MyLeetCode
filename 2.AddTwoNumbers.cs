/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example
Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode result = null;
        ListNode tNode = null;
        int carry = 0;
        while(!(l1 == null && l2 == null))
        {
            int a = l1 == null ? 0 : l1.val;
            int b = l2 == null ? 0 : l2.val;
            ListNode node = new ListNode(a + b + carry);
            if(l1 != null) l1 = l1.next;
            if(l2 != null) l2 = l2.next;
            carry = node.val / 10;
            node.val = node.val % 10;
            if(result == null)
            {
                result = node;
                tNode = result;
            }else
            {
                tNode.next = node;
                tNode = tNode.next;
            }
        }
        if(carry != 0)
        {
            ListNode node = new ListNode(1);
            tNode.next = node;
        }
        return result;
    }
}