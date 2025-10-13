using System;

class Program 
{
  public static void Main(string[] args) 
  {
    int n = int.Parse(Console.ReadLine());
    int[] counts = new int[n + 1];

    Console.WriteLine(GetCount(n));

    //재귀 함수의 사용법을 좀 더 숙지할 필요가 있음.
    //그리디 처럼 우선순위가 있는 경우가 아님... 모든 경우를 다 테스트해봐야 함.
    //점화식: counts[i] = min(counts[i-1], counts[i/2], counts[i/3], counts[i/5]) + 1
    int GetCount(int num)
    {
      if (num == 1)
      {
        return 0;
      }
      
      if (counts[num] != 0)
      {
        return counts[num];
      }
      
      int minValue = int.MaxValue;

      if (num % 5 == 0)
      {
        int count = GetCount(num / 5) + 1;
        if (count < minValue)
        {
          minValue = count;
        }
      }

      if (num % 3 == 0)
      {
        int count = GetCount(num / 3) + 1;
        if (count < minValue)
        {
          minValue = count;
        }
      }

      if (num % 2 == 0)
      {
        int count = GetCount(num / 2) + 1;
        if (count < minValue)
        {
          minValue = count;
        }
      }
      
      {
        int count = GetCount(num - 1) + 1;
        if (count < minValue)
        {
          minValue = count;
        }
      }

      //메모리에 저장해야 함!
      counts[num] = minValue;
      return minValue;
    }
  }
}
