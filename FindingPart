using System;
using System.Collections.Generic;
using System.Text;

class Program 
{
    public static void Main(string[] args)
    {
        StringBuilder answerSB = new StringBuilder();

        int n = int.Parse(Console.ReadLine());
        List<int> parts = new List<int>();
        string[] partsStrings = Console.ReadLine().Split(' ');

        int m = int.Parse(Console.ReadLine());
        string[] requirePartsStrings = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            parts.Add(int.Parse(partsStrings[i]));
        }

        //Before binary search, it needs sort.
        parts.Sort();

        for (int i = 0; i < m; i++)
        {
            int curTargetNum = int.Parse(requirePartsStrings[i]);
            answerSB.Append(SearchBinary(0, parts.Count - 1, curTargetNum) + " ");
        }

        //Line alignment
        Console.WriteLine(answerSB.ToString().TrimEnd());

        string SearchBinary(int startIdx, int endIdx, int targetNum)
        {
            if (endIdx < startIdx)
            {
                return "no";
            }

            int midIdx = (startIdx + endIdx) / 2;
            int midNum = parts[midIdx];

            if (targetNum == midNum)
            {
                return "yes";
            }
            else if (targetNum < midNum)
            {
                return SearchBinary(startIdx, midIdx - 1, targetNum);
            }
            else
            {
                return SearchBinary(midIdx + 1, endIdx, targetNum);
            }
        }
    }
}
