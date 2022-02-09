namespace Evaluate_Division;

public class Solution
{
	// Key: variable	Value: (parent, factor of parent)
	public Dictionary<string, (string, double)> Graph { get; set; }
	
	public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
	{
		Graph = new Dictionary<string, (string, double)>();
		
		var graphSize = values.Length;
		
		// Construct the graph
		for (int i = 0; i < graphSize; i++)
		{
			Union(equations[i][0], equations[i][1], values[i]);
		}
		
		var resultSize = queries.Count;
		var results = new double[resultSize];
		
		// Compute the result
		for (int i = 0; i < resultSize; i++)
		{
			var varX = queries[i][0];
			var varY = queries[i][1];
			if (!Graph.ContainsKey(varX) || !Graph.ContainsKey(varY))
			{
				results[i] = -1;
				continue;
			}

			var rootX = Find(varX);
			var rootY = Find(varY);

			if (!rootX.Equals(rootY))
			{
				results[i] = -1;
				continue;
			}

			var (_, factorX) = Graph[varX];
			var (_, factorY) = Graph[varY];

			results[i] = (double) factorX / factorY;
		}

		return results;
	}

	public void Union(string x, string y, double factor)
	{
		Graph.TryAdd(x, (x, 1));
		Graph.TryAdd(y, (y, 1));
		
		// Find and update the root and factor on the path
		var rootX = Find(x);
		var rootY = Find(y);

		if (rootX.Equals(rootY))
			return;

		var (_, xToRootXFactor) = Graph[x];
		var (_, yToRootYFactor) = Graph[y];

		var newFactor = yToRootYFactor / xToRootXFactor * factor;

		Graph[x] = (rootY, newFactor);
	}
	
	public string Find(string x)
	{
		if (!Graph.ContainsKey(x))
			return null;
		
		var (parent, factor) = Graph[x];

		if (parent.Equals(x))
			return x;

		var newParent = Find(parent);
		var newFactor = factor * Graph[parent].Item2;

		Graph[x] = (newParent, newFactor);

		return newParent;
	}
}