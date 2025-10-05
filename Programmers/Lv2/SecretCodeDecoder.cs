using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int n, int[,] q, int[] ans) 
    {
        int answer = 0;
        HashSet<int> curNums = new HashSet<int>();
        
        for (int first = 1; first <= n - 4; first++)
        {
            for (int second = first + 1; second <= n - 3; second++)
            {
                for (int third = second + 1; third <= n - 2; third++)
                {
                    for (int fourth = third + 1; fourth <= n - 1; fourth++)
                    {
                        for (int fifth = fourth + 1; fifth <= n; fifth++)
                        {
                            curNums.Clear();
                            curNums.Add(first);
                            curNums.Add(second);
                            curNums.Add(third);
                            curNums.Add(fourth);
                            curNums.Add(fifth);
                            
                            if (IsValuableTrial(q, ans, curNums))
                            {
                                answer++;
                            }
                        }
                    }
                }
            }
        }
        
        return answer;
    }
    
    private bool IsValuableTrial(int[,] q, int[] ans, HashSet<int> curNums)
    {
        for (int i = 0; i < ans.Length; i++)
        {
            int curAns = ans[i];
            int containNums = 0;
                
            for (int k = 0; k < 5; k++)
            {
                if (curNums.Contains(q[i, k]))
                {
                    containNums++;
                }
            }
                
            if (curAns != containNums)
            {
                return false;
            }
        }
            
        return true;
    }
}
