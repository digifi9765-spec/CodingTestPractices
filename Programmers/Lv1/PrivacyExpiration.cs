using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(string today, string[] terms, string[] privacies) 
    {
        Dictionary<string, int> termsDict = new Dictionary<string, int>();
        int todayNum = GetDateNum(today);
        List<int> overPrivacies = new List<int>();
        
        foreach (string term in terms)
        {
            string[] splited = term.Split(' ');
            string kind = splited[0];
            int months = int.Parse(splited[1]);
            
            termsDict.Add(kind, months);
        }
        
        for (int i = 0; i < privacies.Length; i++)
        {
            string privacy = privacies[i];
            string[] splited = privacy.Split(" ");
            string date = splited[0];
            string term = splited[1];
            int overDateNum = GetDateNumAddingMonths(date, termsDict[term]);
            
            if (todayNum >= overDateNum)
            {
                overPrivacies.Add(i + 1);
            }
        }
        
        return overPrivacies.ToArray();
    }
    
    private int GetDateNum(string date)
    {
        string[] splited = date.Split('.');
        int year = int.Parse(splited[0]);
        int month = int.Parse(splited[1]);
        int day = int.Parse(splited[2]);
        
        return year * 10000 + month * 100 + day;
    }
    
    private int GetDateNumAddingMonths(string date, int additionalMonths)
    {
        string[] splited = date.Split('.');
        int year = int.Parse(splited[0]);
        int month = int.Parse(splited[1]);
        int day = int.Parse(splited[2]);
        
        int newMonth = month + additionalMonths;
        
        while (newMonth > 12)
        {
            year++;
            newMonth -= 12;
        }
        
        return year * 10000 + newMonth * 100 + day;
    }
}
