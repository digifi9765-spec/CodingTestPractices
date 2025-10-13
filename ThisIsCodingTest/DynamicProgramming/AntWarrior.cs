using System;

class Program 
{
  public static void Main(string[] args) 
  {
    int n = int.Parse(Console.ReadLine());
    string[] strings = Console.ReadLine().Split(' ');
    int[] storage = new int[strings.Length];
    int[] dp = new int[n];

    for (int i = 0; i < strings.Length; i++)
    {
      storage[i] = Convert.ToInt32(strings[i]);
    }

    //0번째 인덱스까지 봤을 때의 최대 이득 값 = 0번째 인덱스 값
    dp[0] = storage[0];
    dp[1] = Math.Max(dp[0], storage[1]);

    for (int i = 2; i < n; i++)
    {
      dp[i] = Math.Max(dp[i - 1], dp[i - 2] + storage[i]);
    }

    Console.WriteLine(dp[n - 1]);
  }
}
