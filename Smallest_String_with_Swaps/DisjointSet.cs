namespace Smallest_String_with_Swaps;

public class DisjointSet
{
	public int[] Root { get; set; }
	public int[] Rank { get; set; }

	public DisjointSet(int size)
	{
		Root = new int[size];
		Rank = new int[size];

		for (int i = 0; i < size; i++)
		{
			Root[i] = i;
			Rank[i] = 1;
		}
	}

	// Implement path compression
	public int Find(int x)
	{
		if (Root[x] == x)
			return x;

		Root[x] = Find(Root[x]);

		return Root[x];
	}

	// Implement union by rank
	public void Union(int x, int y)
	{
		var rootX = Find(x);
		var rootY = Find(y);

		if (rootX == rootY)
			return;

		if (Rank[rootX] > Rank[rootY])
			Root[rootY] = rootX;
		else
		{
			Root[rootX] = rootY;

			if (Rank[rootX] == Rank[rootY])
				Rank[rootY]++;
		}
	}
}