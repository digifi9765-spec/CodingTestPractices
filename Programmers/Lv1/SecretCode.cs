using System;
using System.Text;
using System.Collections.Generic;

public class Solution 
{ 
    public string solution(string s, string skip, int index) 
    {
        StringBuilder stringBuilder = new StringBuilder();
        HashSet<char> skippedHashSet = new HashSet<char>(skip);
            
        for (int i = 0; i < s.Length; i++)
        {
            stringBuilder.Append(GetSecretAlphabet(s[i], index, skippedHashSet));
        }
        
        return stringBuilder.ToString();
    }
    
    private char GetSecretAlphabet(char alphabet, int index, HashSet<char> skippedHashSet)
    {
        int remainingCount = index;
        char curAlphabet = alphabet;

        while (remainingCount > 0)
        {
            curAlphabet++;
            
            if (curAlphabet > 'z')
            {
                curAlphabet = 'a';
            }

            if (skippedHashSet.Contains(curAlphabet))
            {
                continue;
            }
            
            remainingCount--;
        }
        
        return curAlphabet;
    }
}
