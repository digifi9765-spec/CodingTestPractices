using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int n, int m, int[] section) 
    {
        int answer = 0;
        List<int> sectionList = new List<int>(section);
        
        while (0 < sectionList.Count)
        {
            int curStartSection = sectionList[0];
            
            for (int i = 0; i < m; i++)
            {
                sectionList.Remove(curStartSection + i);
            }
            
            answer++;
        }
        
        return answer;
    }
}
