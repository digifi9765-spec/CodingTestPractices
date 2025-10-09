using System;

public class Solution 
{
    public int solution(int k, int m, int[] score) 
    {
        int answer = 0;
        Array.Sort(score);
        
        for (int i = score.Length - m; 0 <= i; i -= m)
        {
            answer += score[i] * m;
        }
        
        return answer;
    }
}
