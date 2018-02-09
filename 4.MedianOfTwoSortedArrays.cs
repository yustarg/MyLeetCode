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


// 官方的solution
public double FindMedianSortedArrays()
{
    if (nums2.Length < nums1.Length)
    {
        int[] temp = nums2;
        nums2 = nums1;
        nums1 = temp;
    }
    int m = nums1.Length;
    int n = nums2.Length;
    bool isEven = (m + n) % 2 == 0;
    int iMax = m, iMin = 0;
    double result = 0;
    while (iMin <= iMax)
    {
        int i = (iMax + iMin + 1) / 2;
        int j = (m + n + 1) / 2 - i;
        if (i > iMin && nums1[i - 1] > nums2[j])
        {
            iMax--;
        }
        else if (i < iMax && nums2[j - 1] > nums1[i])
        {
            iMin++;
        }
        else
        {
            double maxLeft = 0;
            if (i == 0)
            {
                maxLeft = nums2[j - 1];
            }
            else if (j == 0)
            {
                maxLeft = nums1[i - 1];
            }
            else
            {
                maxLeft = (double)(Math.Max(nums1[i - 1], nums2[j - 1])); 
            }
            if (!isEven) return maxLeft;

            double minRight = 0;
            if (i == m)
            {
                minRight = nums2[j];
            }
            else if (j == n)
            {
                minRight = nums1[i];
            }
            else
            {
                minRight = (double)(Math.Min(nums1[i], nums2[j]));
            }
            result = (minRight + maxLeft) / 2;
            return result;
        }
    }
    return result;
}