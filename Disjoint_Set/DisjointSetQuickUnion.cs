namespace Disjoint_Set;

public class DisjointSetQuickUnion : DisjointSet
{
	public DisjointSetQuickUnion(int size) : base(size)
	{
	}

	protected DisjointSetQuickUnion()
	{
	}

	// Store parent nodes in the array
	// But the these parent nodes are not those in the original graph
	// When connecting two nodes, only connect their root nodes
	// Only update the parent node of either root node, not any of its child node
	public override void Union(int x, int y)
	{
		var rootX = Find(x);
		var rootY = Find(y);

		if (rootX != rootY)
			Root[rootY] = rootX;
	}

	public override int Find(int x)
	{
		while (Root[x] != x)
			x = Root[x];

		return x;
	}
}