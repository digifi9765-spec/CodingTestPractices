using System;
using System.Collections.Generic;

public class Solution 
{
    private int _rowCount;
    private int _colCount;
    private string[] _storage;
    private (int row, int col)[] _directions = 
    {
        (-1 , 0),
        (1, 0),
        (0, -1),
        (0, 1)
    };
    
    private HashSet<(int row, int col)> _nullContainers = new HashSet<(int row, int col)>();
    
    public int solution(string[] storage, string[] requests) 
    {
        _rowCount = storage.Length;
        _colCount = storage[0].Length;
        _storage = storage;
        
        for (int i = 0; i < requests.Length; i++)
        {
            char curAlphabet = requests[i][0];
            bool useCrane = requests[i].Length == 2;
            
            if (useCrane)
            {
                GetResultUsingCrane(curAlphabet);
            }
            else 
            {
                GetResultUsingCar(curAlphabet);
            }
        }
        
        return _rowCount * _colCount - _nullContainers.Count;
    }
    
    private void GetResultUsingCrane(char alphabet)
    {
        for (int i = 0; i < _storage.Length; i++)
        {
            for (int k = 0; k < _storage[i].Length; k++)
            {
                if (_storage[i][k].Equals(alphabet))
                {
                    _nullContainers.Add((i, k));
                }
            }
        }
    }
    
    private void GetResultUsingCar(char alphabet)
    {
        List<(int row, int col)> tempNullContainerList = new List<(int row, int col)>();
        
        for (int i = 0; i < _storage.Length; i++)
        {
            for (int k = 0; k < _storage[i].Length; k++)
            {
                if (_storage[i][k].Equals(alphabet))
                {
                    if (IsOpen(i, k, new HashSet<(int row, int col)>() { (i, k) }))
                    {
                        tempNullContainerList.Add((i, k));
                    }
                }
            }
        }
        
        for (int i = 0; i < tempNullContainerList.Count; i++)
        {
            _nullContainers.Add((tempNullContainerList[i].row, tempNullContainerList[i].col));
        }
    }
    
    private bool IsValid(int row, int col)
    {
        return 0 <= row && row < _rowCount && 0 <= col && col < _colCount; 
    }
    
    private bool IsEmpty(int row, int col)
    {
        return _nullContainers.Contains((row, col));
    }
    
    private bool IsOpen(int row, int col, HashSet<(int row, int col)> visitPoses)
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            int curRow = row + _directions[i].row;
            int curCol = col + _directions[i].col;
            
            if (visitPoses.Contains((curRow, curCol)))
            {
                continue;
            }
            
            if (!IsValid(curRow, curCol))
            {
                return true;
            }
            
            if (IsEmpty(curRow, curCol))
            {
                visitPoses.Add((curRow, curCol));

                if (IsOpen(curRow, curCol, visitPoses))
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
