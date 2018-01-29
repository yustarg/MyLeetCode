/*
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.
Given "bbbbb", the answer is "b", with the length of 1.
Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/

public int LengthOfLongestSubstring(string s)
{
    if (string.IsNullOrEmpty(s)) return 0;
    int i = 0, j = 0, max = 0, n = s.Length;
    Dictionary<int, char> map = new Dictionary<int, char>();
    while(i < n && j < n)
    {
        if (!map.ContainsValue(s[j]))
        {
            map.Add(j, s[j]);
            j++;
            max = Math.Max(max, j - i);
        }
        else {
            map.Remove(i);
            i++;
        }
    }
    return max;
}