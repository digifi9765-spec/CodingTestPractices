using System;

public class Solution {
    public int[] solution(string s) 
    {
        //알파벳들의 마지막 등장 인덱스, 한 번도 등장하지 않았으면 -1을 할당
        int[] lastIndices = new int[26];
        int[] results = new int[s.Length];

      //배열의 모든 요소의 값을 -1로 해주는 코드
        Array.Fill(lastIndices, -1);
        
        for (int i = 0; i < s.Length; i++)
        {
            char curAlphabet = s[i];
            //산술 연산자 사용 시에 명시적 형 변환은 필요 없음
            int curAlphabetIndex = curAlphabet - 'a';
            results[i] = lastIndices[curAlphabetIndex] == -1 ? -1 : i - lastIndices[curAlphabetIndex];
            lastIndices[curAlphabetIndex] = i;
        }
        
        return results;
    }
}
