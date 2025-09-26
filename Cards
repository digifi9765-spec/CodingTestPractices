using System;
using System.Collections.Generic;

public class Solution 
{
    public string solution(string[] cards1, string[] cards2, string[] goal) 
    {
        int cards1Idx = 0;
        int cards2Idx = 0;
        
        foreach (string curWord in goal)
        {
            if (cards1Idx < cards1.Length && cards1[cards1Idx] == curWord)
            {
                cards1Idx++;
            }
            else if (cards2Idx < cards2.Length && cards2[cards2Idx] == curWord)
            {
                cards2Idx++;
            }
            else
            {
                return "No";
            }
        }
        
        return "Yes";
    }
}
