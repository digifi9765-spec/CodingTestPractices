using System;

public class Solution 
{
    public int solution(string s) 
    {
        char x = '\0';
        int xCount = 0;
        int otherCount = 0;
        int answer = 0;
        
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (x == '\0')
            {
                x = s[i];
            }
            
            if (s[i] == x)
            {
                xCount++;
            }
            else
            {
                otherCount++;
            }
            
            if (xCount == otherCount)
            {
                x = '\0';
                xCount = 0;
                otherCount = 0;
                answer++;
            }
        }
        
        return ++answer;
    }
}
