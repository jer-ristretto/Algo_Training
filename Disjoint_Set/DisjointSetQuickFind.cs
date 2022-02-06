namespace Disjoint_Set;

public class DisjointSetQuickFind : DisjointSet
{
	public DisjointSetQuickFind(int size) : base(size)
	{
	}

	// Only root nodes are stored in the array
	// Update the root node of every node connected to y
	public override void Union(int x, int y)
	{
		if (Find(x) == Find(y))
			return;
		
		for (int i = 0; i < Root.Length; i++)
		{
			if (Root[i] != Find(y))
				continue;
			
			Root[i] = Find(x);
		}
	}

	public override int Find(int x)
	{
		return Root[x];
	}
}