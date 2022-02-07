using System.Text;

namespace Smallest_String_with_Swaps;

public class Solution
{
	public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
	{
		var size = s.Length;
		
		// Base cases
		if (s is null)
			return null;
		if (size <= 1)
			return s;
		
		var disjointSet = new DisjointSet(size);
		
		foreach (var pair in pairs)
			disjointSet.Union(pair[0], pair[1]);

		var graphGroup = new Dictionary<int, PriorityQueue<char, char>>();

		for (int i = 0; i < size; i++)
		{
			// After the loop finishes, all roots in the array are updated
			var root = disjointSet.Find(i);
			
			// Add the character to the priority queue labelled by the root
			graphGroup.TryAdd(root, new PriorityQueue<char, char>());
			graphGroup[root].Enqueue(s[i], s[i]);
		}

		var stringBuilder = new StringBuilder();
		var roots = disjointSet.Root;
		
		for (int i = 0; i < size; i++)
		{
			// Dequeue the character from the priority queue labelled by the root
			var character = graphGroup[roots[i]].Dequeue();
			stringBuilder.Append(character);
		}

		return stringBuilder.ToString();
	}
}