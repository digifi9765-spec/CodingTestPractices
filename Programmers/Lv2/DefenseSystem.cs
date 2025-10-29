// 찾아보니까 사실 그리디 알고리즘 문제라고 함... 
// 어쩌다가 아슬아슬하게 정답 처리됨...

using System;
using System.Collections.Generic;

public class DefenseSystem
{
    public int min; //방어 시스템이 커버할 수 있는 최소 x값
    public int max; //방어 시스템이 커버할 수 있는 최대 x값
    
    public DefenseSystem(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}

public class Solution 
{
    public int solution(int[,] targets) 
    {        
        //정렬을 위해 List를 씀
        List<int[]> targetList = new List<int[]>();
        
        for (int i = 0; i < targets.GetLength(0); i++)
        {
            //int[] 타입 변수를 생성하는 것에 유의
            targetList.Add(new int[] { targets[i, 0], targets[i, 1] });
        }
        
        //Sort 로직 커스텀 방식에 유의.
        //첫 번째 값이 같을 경우, 두 번째 값으로 결정함.
        targetList.Sort((a, b) => 
        {
            int primary = a[0].CompareTo(b[0]);
            
            if (primary == 0)
            {
                return a[1].CompareTo(b[1]);
            }
            
            return primary;
        });
        
        List<DefenseSystem> dsList = new List<DefenseSystem>();
        
        for (int i = 0; i < targetList.Count; i++)
        {
            int curMin = targetList[i][0];
            int curMax = targetList[i][1];
            bool needNewSystem = true;

            //이거 foreach문으로 작성하면 시간 초과로 바로 틀림
            for (int k = 0; k < dsList.Count; k++)
            {
                var ds = dsList[k];
                
                if (ds.min <= curMin && curMin < ds.max)
                {
                    ds.min = Math.Max(ds.min, curMin);
                    ds.max = Math.Min(ds.max, curMax);
                    needNewSystem = false;
                    break;
                }
                else if (curMin < ds.min && ds.min < curMax)
                {
                    ds.min = Math.Max(ds.min, curMin);
                    ds.max = Math.Min(ds.max, curMax);
                    needNewSystem = false;
                    break;
                }
            }
            
            if (needNewSystem)
            {
                dsList.Add(new DefenseSystem(curMin, curMax));
            }
        }
        
        return dsList.Count;
    }
}
