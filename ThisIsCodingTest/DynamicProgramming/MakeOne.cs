using System;

class Program 
{
  public static void Main(string[] args) 
  {
    int n = int.Parse(Console.ReadLine());
    int[] counts = new int[n + 1];
    counts[1] = 0;

    //반복문을 써서 해결, 파악하는 과정에서 1부터 n까지의 모든 경우의 수를 알아야 하므로
    for (int i = 2; i <= n; i++)
    {
      int best = counts[i - 1] + 1;
      if (i % 2 == 0) best = Math.Min(best, counts[i / 2] + 1);
      if (i % 3 == 0) best = Math.Min(best, counts[i / 3] + 1);
      if (i % 5 == 0) best = Math.Min(best, counts[i / 5] + 1);
      counts[i] = best;
    }

    Console.WriteLine(GetCount(n));
  }
}
