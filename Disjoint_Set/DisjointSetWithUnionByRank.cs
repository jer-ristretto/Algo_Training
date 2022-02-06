namespace Disjoint_Set;

public class DisjointSetWithUnionByRank : DisjointSetQuickUnion
{
	public int[] Rank { get; set; }		// The height of the node
	
	public DisjointSetWithUnionByRank(int size)
	{
		Root = new int[size];
		Rank = new int[size];
		for (int i = 0; i < size; i++)
		{
			Root[i] = i;
			Rank[i] = 1;
		}
	}

	// Choose the root node with a larger rank to be the new root node
	public override void Union(int x, int y)
	{
		var rootX = Find(x);
		var rootY = Find(y);

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