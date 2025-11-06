using System;

public class Solution 
{
    public long solution(int r1, int r2) 
    {
        // long 타입에 곱셈 결과를 저장하려면, 피연산자 중 하나를 명시적으로 long으로 캐스팅해야 한다.
        // 그렇지 않으면 곱셈 결과가 int로 계산된 뒤 long으로 변환되며,
        // 이때 오버플로우가 발생하면 잘못된 값이 long 변수에 저장된다.

        long r1Sqr = (long)r1*r1;
        long r2Sqr = (long)r2*r2;
        long pointCount = 0;
        
        for (int x = 1; x < r2; x++)
        {
            long xSqr = (long)x*x;
            long maxY = (long)Math.Floor(Math.Sqrt(r2Sqr - xSqr));
            long minY = (long)Math.Ceiling(Math.Sqrt(Math.Max(r1Sqr - xSqr, 0)));
            pointCount += minY == 0 ? maxY : maxY - minY + 1;
        }
        
        pointCount *= 4;
        pointCount += (r2 - r1 + 1) * 4;
        
        return pointCount;
    }
}
