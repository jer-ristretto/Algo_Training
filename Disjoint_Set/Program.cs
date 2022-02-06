using Disjoint_Set;

var disjointSet = new DisjointSetWithUnionByRank(10);

disjointSet.Union(1, 2);
disjointSet.Union(2, 5);
disjointSet.Union(5, 6);
disjointSet.Union(6, 7);
disjointSet.Union(3, 8);
disjointSet.Union(8, 9);

Console.WriteLine(disjointSet.Connected(1, 5)); // true
Console.WriteLine(disjointSet.Connected(5, 7)); // true
Console.WriteLine(disjointSet.Connected(4, 9)); // false
// 1-2-5-6-7 3-8-9-4

disjointSet.Union(9, 4);
Console.WriteLine(disjointSet.Connected(4, 9)); // true

var disjointSetwithPathComp = new DisjointSetWithPathCompression(10);
var rootArray = disjointSetwithPathComp.Root;

for (int i = 1; i < rootArray.Length; i++)
	rootArray[i] = i - 1;

for (int i = 0; i < rootArray.Length; i++)
	Console.Write(rootArray[i]);
	
Console.WriteLine();

disjointSetwithPathComp.Find(4);

for (int i = 0; i < rootArray.Length; i++)
	Console.Write(rootArray[i]);
	
Console.WriteLine();

disjointSetwithPathComp.Find(8);

for (int i = 0; i < rootArray.Length; i++)
	Console.Write(rootArray[i]);
	
Console.WriteLine();