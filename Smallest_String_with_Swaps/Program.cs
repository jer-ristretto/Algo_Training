using Smallest_String_with_Swaps;

var solution = new Solution();

var inputString = "dcab";
IList<IList<int>> inputPairs = new List<IList<int>>();
inputPairs.Add(new List<int> {1, 2});
inputPairs.Add(new List<int> {0, 3});
inputPairs.Add(new List<int> {0, 2});

var outputString = solution.SmallestStringWithSwaps(inputString, inputPairs);

Console.WriteLine(outputString);