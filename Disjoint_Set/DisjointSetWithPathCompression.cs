namespace Disjoint_Set;

public class DisjointSetWithPathCompression : DisjointSetQuickUnion
{
	public DisjointSetWithPathCompression(int size) : base(size)
	{
	}

	public override int Find(int x)
	{
		if (Root[x] == x)
			return x;

		Root[x] = Find(Root[x]);

		return Root[x];
	}
}