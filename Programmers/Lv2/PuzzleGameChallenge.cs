using System;

public class Solution 
{
    public int solution(int[] diffs, int[] times, long limit) 
    {
        int min = 1;
        int max = GetMaxDiff(diffs);
        int lastSuccessLevel = 0;

        while (min <= max)
        {
            int mid = (min + max) / 2;
            long elapsedTime = GetElapsedTime(diffs, times, limit, mid);
            
            if (elapsedTime < 0 /*현재 레벨에서 실패.*/)
            {
                min = mid + 1;
            }
            else /*현재 레벨에서 성공, 그러나 최소값이 존재할 수 있으므로 탐색을 계속 해야 함.*/
            {
                lastSuccessLevel = mid;
                max = mid - 1;
            }
        }
        
        return lastSuccessLevel;
    }
    
    private int GetMaxDiff(int[] diffs)
    {
        int maxDiff = 0;
        
        for (int i = 0; i < diffs.Length; i++)
        {
            if (maxDiff < diffs[i])
            {
                maxDiff = diffs[i];
            }
        }
        
        return maxDiff;
    }
    
    private long GetElapsedTime(int[] diffs, int[] times, long limit, int level)
    {
        long elapsedTime = 0;
        
        for (int i = 0; i < diffs.Length; i++)
        {
            int curDiff = diffs[i];
            int curTime = times[i];
            int useTime = 0;
            
            if (level < curDiff)
            {
                int prevTime = times[i - 1];
                elapsedTime += (prevTime + curTime) * (curDiff - level) + curTime;
            }
            else
            {
                elapsedTime += curTime;
            }
            
            if (limit < elapsedTime)
            {
                return -1;
            }
        }
        
        return elapsedTime;
    }
}
