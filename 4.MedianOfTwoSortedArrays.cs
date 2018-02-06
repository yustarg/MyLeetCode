/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.
Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

Example 1:
nums1 = [1, 3]
nums2 = [2]
The median is 2.0

Example 2:
nums1 = [1, 2]
nums2 = [3, 4]
The median is (2 + 3)/2 = 2.5
*/

// 用了插入排序，虽然答案对了，但真正的算法并不是这样
// https://leetcode.com/problems/median-of-two-sorted-arrays/solution/
public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
{
    int m = nums1.Length;
    int n = nums2.Length;
    int finalLenght = m + n;
    if(finalLenght == 0) return 0;
    double[] final = new double[finalLenght];
    Array.Copy(nums1, final, m);
    Array.Copy(nums2, 0, final, m, n);
    double result = 0;
    for (int i = 1; i < finalLenght; i++)
    {
        double temp = final[i];
        for (int j = i - 1; j >= 0; j--)
        {
            if (temp < final[j])
            {
                final[j + 1] = final[j];
                final[j] = temp;
            }
        }
    }

    if ((finalLenght) % 2 == 0)
    {
        int a = finalLenght / 2;
        int b = a - 1;
        result = (final[a] + final[b]) / 2;
    }
    else
    {
        int a = (int)Math.Floor((double)finalLenght / 2);
        result = final[a];
    }
    return result;
}