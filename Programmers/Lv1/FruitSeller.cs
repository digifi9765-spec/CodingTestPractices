using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int k, int m, int[] score) 
    {
        int answer = 0;
        List<int> scoreList = new List<int>();

        for (int i = 0; i < score.Length; i++)
        {
            scoreList.Add(score[i]);
        }
        
        scoreList.Sort();
        
        int curMinScore = int.MaxValue;
        int curCount = 0;
        
        for (int i = scoreList.Count - 1; 0 <= i; i--)
        {
            int curScore = scoreList[i];
            
            if (curScore < curMinScore)
            {
                curMinScore = curScore;
            }
            
            curCount++;
            
            if (curCount == m)
            {
                answer += curMinScore * m;
                curMinScore = int.MaxValue;
                curCount = 0;

                if (i < m - 1)
                {
                  break;
                }
            }
        }
        
        return answer;
    }
}
