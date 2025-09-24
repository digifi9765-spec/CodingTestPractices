using System;

public class Solution 
{
    public int[] solution(string[] keymap, string[] targets)
    {
        int[] answer = new int[targets.Length];
        int[] alphabetMinPushCounts = new int[26];
        int integerA = (int)'A';
        
        for (int i = 0; i < 26; i++)
        {
            alphabetMinPushCounts[i] = GetAlphabetMinPushCount(keymap, (char)(integerA + i));
        }
        
        for (int i = 0; i < targets.Length; i++)
        {
            int curSum = 0;
            
            for (int k = 0; k < targets[i].Length; k++)
            {
                int curAlphabetMinCount = alphabetMinPushCounts[(int)targets[i][k] - integerA];
                
                if (curAlphabetMinCount >= 100)
                {
                    curSum = -1;
                    break;
                }
                else
                {
                    curSum += curAlphabetMinCount;
                }
            }
            
            answer[i] = curSum;
        }
        
        return answer;
    }
    
    private static int GetAlphabetMinPushCount(string[] keymap, char alphabet)
    {
        int minCount = 100;
        
        for (int i = 0; i < keymap.Length; i++)
        {
            for (int k = 0; k < keymap[i].Length; k++)
            {
                if (keymap[i][k] == alphabet)
                {
                    if (k < minCount)
                    {
                        minCount = k + 1;
                    }
                }
            }
        }
        
        return minCount;
    }
}
