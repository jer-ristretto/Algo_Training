namespace Number_of_Provinces;

// Take input from test cases
public class Solution
{
	public int FindCircleNum(int[][] isConnected)
	{
		var size = isConnected.Length;
		var disjointSet = new DisjointSet(size);

		for (int i = 0; i < size; i++)
		{
			for (int j = i + 1; j < size; j++)
			{
				if (isConnected[i][j] == 1)
				{
					disjointSet.Union(i, j);
				}
			}
		}

		return disjointSet.NumOfRoots;
	}
}