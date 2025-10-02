using System;

public class Solution 
{
    public int solution(string t, string p) 
    {
        int answer = 0;
        
        for (int i = 0; i + p.Length <= t.Length; i++)
        {
            string curText = t.Substring(i, p.Length);
            //사전식 비교(문자 코드 순서를 비교)를 통해 문자열 간 크기 판단
            //음수(-1)면 p < curText
            //양수(1)면 p > curText
            //크기가 같으면 p == curText
            int result = String.CompareOrdinal(p, curText);
            
            if (0 <= result)
            {
                answer++;
            }
        }
        
        return answer;
    }
}
