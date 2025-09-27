using System;
using System.Text;
using System.Collections.Generic;

public class Solution 
{
    private static int ZIndex = (int)'z';
  
    public string solution(string s, string skip, int index) 
    {
        StringBuilder stringBuilder = new StringBuilder();
        List<int> skippedIndices = new List<int>();
        
        for (int i = 0; i < skip.Length; i++)
        {
            skippedIndices.Add((int)skip[i]);
        }
        
        for (int i = 0; i < s.Length; i++)
        {
            stringBuilder.Append(GetSecretAlphabet(s[i], index, skippedIndices));
        }
        
        return stringBuilder.ToString();
    }
    
    private char GetSecretAlphabet(char alphabet, int index, List<int> skippedIndices)
    {
        int alphabetIndex = (int)alphabet;
        
        for (int i = 0; i < index; i++)
        {
            alphabetIndex++;
            
            if (alphabetIndex > ZIndex)
            {
                alphabetIndex = (int)'a';
            }
            
            if (skippedIndices.Contains(alphabetIndex))
            {
                index++;
            }
        }
        
        return (char)alphabetIndex;
    }
}
