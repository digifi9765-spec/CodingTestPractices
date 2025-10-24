#include <string>
#include <vector>
#include <algorithm>
#include <set>

using namespace std;

int solution(vector<int> mats, vector<vector<string>> park) 
{
    int maxRow = park.size();
    int maxCol = park[0].size();
    int maxLength = 0;
    vector<vector<int>> dp(maxRow, vector<int>(maxCol, 0));
    
    for (int r = 0; r < maxRow; r++)
    {
        for (int c = 0; c < maxCol; c++)
        {
            if (park[r][c] != "-1")
            {
                continue;
            }
            
            if (r < 1 || c < 1)
            {
                dp[r][c] = 1;
                
                if (maxLength < dp[r][c])
                {
                    maxLength = dp[r][c];
                }
                
                continue;
            }
            
            dp[r][c] = 1 + min({dp[r-1][c], dp[r][c-1], dp[r-1][c-1]});
            
            if (maxLength < dp[r][c])
            {
                maxLength = dp[r][c];
            }
        }
    }
    
    sort(mats.begin(), mats.end(), greater<int>());
    
    for (int i = 0; i < mats.size(); i++)
    {
        if (mats[i] <= maxLength)
        {
            return mats[i];
        }
    }
    
    return -1;
}
