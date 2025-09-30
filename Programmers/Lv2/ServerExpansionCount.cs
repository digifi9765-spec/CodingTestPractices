using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int[] players, int m, int k) 
    {
        List<int> serverPassedTimes = new List<int>();
        int expansionServerCount = 0;
        
        for (int i = 0; i < players.Length; i++)
        {
            //리스트에서 순회 Remove 연산을 할 때는 뒤에서 해야 한다... 이것 때문에 계속 틀림
            for (int j = serverPassedTimes.Count - 1; j >= 0; j--)
            {
                if (++serverPassedTimes[j] == k)
                {
                    serverPassedTimes.RemoveAt(j);
                }
            }
            
            int curPlayerNum = players[i];
            
            while (curPlayerNum >= (serverPassedTimes.Count + 1) * m)
            {
                serverPassedTimes.Add(0);
                expansionServerCount++;
            }
        }
        
        return expansionServerCount;
    }
}
