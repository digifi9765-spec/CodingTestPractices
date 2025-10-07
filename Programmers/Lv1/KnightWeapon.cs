using System;

public class Solution 
{
    public int solution(int number, int limit, int power) 
    {
        int sum = 0;
        
        for (int i = 0; i < number; i++)
        {
            int curPower = GetDivisorsNum(i + 1);
            
            if (limit < curPower)
            {
                curPower = power;
            }
            
            sum += curPower;
        }
        
        return sum;
    }
    
    public int GetDivisorsNum(int num)
    {
        int divisorsNum = 0;
        
        for (int i = 1; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                divisorsNum++;
            }
        }
        
        return ++divisorsNum;
    }
}
