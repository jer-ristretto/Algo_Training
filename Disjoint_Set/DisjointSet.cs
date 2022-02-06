namespace Disjoint_Set;

public abstract class DisjointSet
{
	public int[] Root { get; set; }

	public DisjointSet(int size)
	{
		Root = new int[size];
		
		for (int i = 0; i < size; i++)
     	{
     		Root[i] = i;
     	}
	}

	protected DisjointSet()
	{
	}

	public abstract void Union(int x, int y);
	public abstract int Find(int x);

	public bool Connected(int x, int y)
	{
		return Find(x) == Find(y);
	}
}