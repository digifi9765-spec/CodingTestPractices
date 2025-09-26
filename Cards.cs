using System;
using System.Collections.Generic;

public class Solution 
{
    public string solution(string[] cards1, string[] cards2, string[] goal) 
    {
        Queue<string> cards1Queue = new Queue<string>();
        Queue<string> cards2Queue = new Queue<string>();
        
        for (int i = 0; i < cards1.Length; i++)
        {
            cards1Queue.Enqueue(cards1[i]);
        }
        
        for (int i = 0; i < cards2.Length; i++)
        {
            cards2Queue.Enqueue(cards2[i]);
        }
        
        for (int i = 0; i < goal.Length; i++)
        {
            string curWord = goal[i];
                        
            if (cards1Queue.Count > 0 && cards1Queue.Peek().Equals(curWord))
            {
                cards1Queue.Dequeue();
            }
            else if (cards2Queue.Count > 0 && cards2Queue.Peek().Equals(curWord))
            {
                cards2Queue.Dequeue();
            }
            else
            {
                return "No";
            }
        }
        
        return "Yes";
    }
}
