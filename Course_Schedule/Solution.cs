namespace Topological_Sort;

public class Solution
{
	public int[] FindOrder(int numCourses, int[][] prerequisites)
	{
		var (graph, inDegree) = buildGraph(numCourses, prerequisites);

		var sourceQueue = new Queue<int>();

		for (int i = 0; i < numCourses; i++)
		{
			if (inDegree[i] == 0)
				sourceQueue.Enqueue(i);
		}

		var order = new int[numCourses];
		var index = 0;

		while (sourceQueue.Count != 0)
		{
			var source = sourceQueue.Dequeue();
			order[index++] = source;

			var neighbours = graph[source];

			if (neighbours is null)
				continue;
			
			for (int i = 0; i < neighbours.Count; i++)
			{
				inDegree[neighbours[i]]--;
				if (inDegree[neighbours[i]] == 0)
					sourceQueue.Enqueue(neighbours[i]);
			}
		}

		if (index != numCourses)
			return new int[]{};

		return order;
	}

	public (List<int>[], int[]) buildGraph(int numCourses, int[][] prerequisites)
	{
		var graph = new List<int>[numCourses];
		var inDegree = new int[numCourses];

		foreach (var pair in prerequisites)
		{
			var from = pair[1];
			var to = pair[0];

			graph[from] ??= new List<int>();
			
			graph[from].Add(to);
			inDegree[to]++;
		}

		return (graph, inDegree);
	}
}