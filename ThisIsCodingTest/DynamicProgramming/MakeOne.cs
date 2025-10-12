using System;

class Program 
{
  public static void Main(string[] args) 
  {
    int n = int.Parse(Console.ReadLine());
    int[] counts = new int[n + 1];

    Console.WriteLine(GetCount(n));

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

      counts[num] = minValue;
      return minValue;
    }
  }
}
