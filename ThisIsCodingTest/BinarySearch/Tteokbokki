using System;
using System.Collections.Generic;

class Program 
{
  public static void Main(string[] args) 
  {
    string[] strings = Console.ReadLine().Split(' ');
    int n = int.Parse(strings[0]);
    int m = int.Parse(strings[1]);
    
    string[] lengthStrings = Console.ReadLine().Split(' ');
    List<int> lengthList = new List<int>();
    
    for (int i = 0; i < n; i++)
    {
      lengthList.Add(int.Parse(lengthStrings[i]));
    }

    lengthList.Sort();

    int maxLength = lengthList[lengthList.Count - 1];
    int minLength = 0;
    int answerLength = -1;

    while (minLength <= maxLength)
    {
      int midLength = (minLength + maxLength) / 2;
      int result = GetTotalCuttingLengths(midLength);

      if (result == m)
      {
        answerLength = midLength;
        break;
      }
      else if (result < m)
      {
        maxLength = midLength - 1;
      }
      else 
      {
        minLength = midLength + 1;
      }
    }

    Console.WriteLine(answerLength);

    return;

    int GetTotalCuttingLengths(int height)
    {
      int sum = 0;

      for (int i = 0; i < lengthList.Count; i++)
      {
        int curLength = lengthList[i];

        if (height < curLength)
        {
          sum += curLength - height;
        }
      }

      return sum;
    }
  }
}
