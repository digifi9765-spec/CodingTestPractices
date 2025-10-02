using System;

public class Solution 
{
    public int solution(string t, string p) 
    {
        int answer = 0;
        //문제에서 주어진 조건 중 하나로, p의 길이가 18 이하이므로 long 자료형을 써야 함
        long pNum = long.Parse(p);
        
        for (int i = 0; i + p.Length <= t.Length; i++)
        {
            string curText = t.Substring(i, p.Length);
            long curNum = long.Parse(curText);
            
            if (curNum <= pNum)
            {
                answer++;
            }
        }
        
        return answer;
        
    }
}
