using System;

class Program 
{
  public static void Main(string[] args) 
  {
    string[] splits = Console.ReadLine().Split(' ');
    int n = int.Parse(splits[0]);
    int m = int.Parse(splits[1]);
    int[] money = new int[n];
    int[] dp = new int[m + 1];
    int minMoneyValue = int.MaxValue; // Money 배열 중 가장 작은 값
    
    Array.Fill(dp, -1);
  
    for (int i = 0; i < n; i++)
    {
      money[i] = int.Parse(Console.ReadLine());
      
      if (m < money[i]) 
      {
        continue;
      }

      if (money[i] < minMoneyValue)
      {
        minMoneyValue = money[i];
      }
      
      dp[money[i]] = 1;
    }

    for (int i = 0; i + minMoneyValue <= m; i++)
    {
      if (dp[i] != -1)
      {
        for (int k = 0; k < n; k++)
        {
          if (m < i + money[k])
          {
            continue;
          }
          
          dp[i + money[k]] = dp[i + money[k]] < 0 ?
            dp[i] + 1: Math.Min(dp[i + money[k]], dp[i] + 1);
        }
      }
    }

    Console.WriteLine(dp[m]);
  }
}
