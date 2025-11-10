using System;

public class Solution 
{
    public int[] solution(int[] sequence, int k) 
    {
        int startIdx = 0; 
        int endIdx = 0;
        int sum = sequence[endIdx];
        int[] answer = null;
        
        while (startIdx <= endIdx && 
               startIdx < sequence.Length)
        {
            if (sum < k)
            {
                if (endIdx == sequence.Length - 1)
                {
                    break;
                }
                
                sum += sequence[++endIdx];
            }
            else if (sum > k)
            {   
                sum -= sequence[startIdx++];
            }
            else
            {
                if (answer == null)
                {
                    answer = new int[2] { startIdx, endIdx };
                }
                else
                {
                    int curLength = endIdx - startIdx + 1;
                    int curAnswerLength = answer[1] - answer[0] + 1;
                    
                    if (curLength < curAnswerLength)
                    {
                        answer[0] = startIdx;
                        answer[1] = endIdx;
                    }
                }

                //start 인덱스를 오른쪽으로 이동: 모든 경우의 수를 고려하기 위함
                sum -= sequence[startIdx++];
            }
        }
        
        return answer;
    }
}
