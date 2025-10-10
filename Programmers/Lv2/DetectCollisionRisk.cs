using System;
using System.Collections.Generic;

public class Solution 
{
    public class Robot
    {
        public int Row;
        public int Col;
        public bool IsFinished = false;
        
        public Queue<int> TargetPointQueue = new Queue<int>();
    }
    
    public int solution(int[,] points, int[,] routes) 
    {
        Robot[] robots = new Robot[routes.GetLength(0)];
        int answer = 0;

        //Initialize Robots
        for (int i = 0; i < routes.GetLength(0); i++)
        {
            int curStartPointIndex = routes[i, 0];
            
            robots[i] = new Robot();
            robots[i].Row = points[curStartPointIndex - 1, 0];
            robots[i].Col = points[curStartPointIndex - 1, 1];
            
            for (int k = 1; k < routes.GetLength(1); k++)
            {
                robots[i].TargetPointQueue.Enqueue(routes[i, k]);
            }
        }

        //처음 위치의 충돌 여부 반영
        answer += GetCollisionCount(robots);
        
        while (IsAllRobotFinished(robots) == false)
        {
            for (int i = 0; i < robots.Length; i++)
            {
                if (robots[i].IsFinished)
                {
                    continue;
                }
                
                if (robots[i].TargetPointQueue.Count == 0)
                {
                    robots[i].IsFinished = true;
                    continue;
                }
                
                MoveRobot(robots[i], points);
            }
            
            answer += GetCollisionCount(robots);
        }
        
        return answer;
    }
    
    public bool IsAllRobotFinished(Robot[] robots)
    {
        for (int i = 0; i < robots.Length; i++)
        {
            if (robots[i].IsFinished == false)
            {
                return false;
            }
        }
        
        return true;
    }
    
    public void MoveRobot(Robot robot, int[,] points)
    {
        int curTargetIndex = robot.TargetPointQueue.Peek();
        int targetRow = points[curTargetIndex - 1, 0];
        int targetCol = points[curTargetIndex - 1, 1];

        if (robot.Row < targetRow)
        {
            //원래 처음에는 robot.Row 대신 curRow 라는 함수 지역 변수를 만들어서 썼었음.
            //curRow 에다 연산을 하면 실제 값에는 반영이 안 되니까 그러면 안 됨.
            robot.Row++;
        } 
        else if (robot.Row > targetRow)
        {
            robot.Row--;
        }
        else if (robot.Col < targetCol)
        {
            robot.Col++;
        }
        else if (robot.Col > targetCol)
        {
            robot.Col--;
        }
                
        if (robot.Row == targetRow && robot.Col == targetCol)
        {
            robot.TargetPointQueue.Dequeue();
        }
    }
    
    public int GetCollisionCount(Robot[] robots)
    {
        int collisionCount = 0;
        HashSet<(int row, int col)> curPoints = new HashSet<(int row, int col)>();
        HashSet<(int row, int col)> collisionPoints = new HashSet<(int row, int col)>();
        
        for (int i = 0; i < robots.Length; i++)
        {
            if (robots[i].IsFinished)
            {
                continue;
            }
            
            int curRow = robots[i].Row;
            int curCol = robots[i].Col;
            
            if (!curPoints.Contains((curRow, curCol)))
            {
                curPoints.Add((curRow, curCol));
            }
            else
            {
                if (!collisionPoints.Contains((curRow, curCol)))
                {
                    collisionCount++;
                    collisionPoints.Add((curRow, curCol));
                }
            }
        }
        
        return collisionCount;
    }
}
