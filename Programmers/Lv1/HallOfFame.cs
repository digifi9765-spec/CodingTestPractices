using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int k, int[] score) 
    {
        List<int> honors = new List<int>();
        int[] answers = new int[score.Length];
        
        for (int i = 0; i < score.Length; i++)
        {
            int curScore = score[i];
            
            if (honors.Count == 0)
            {
                honors.Add(curScore);
            }
            else
            {
                for (int j = honors.Count - 1; 0 <= j; j--)
                {
                    if (honors[j] < curScore)
                    {
                        honors.Insert(j + 1, curScore);
                        break;
                    }
                    
                    if (j == 0)
                    {
                        honors.Insert(0, curScore);
                    }
                }
            }
            
            if (k < honors.Count)
            {
                honors.RemoveAt(0);
            }
            
            answers[i] = honors[0];
        }
        
        return answers;
    }
}
