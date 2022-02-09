using Evaluate_Division;

var solution = new Solution();

IList<IList<string>> equations = new List<IList<string>>();
equations.Add(new List<string> {"a", "b"});
equations.Add(new List<string> {"b", "c"});
equations.Add(new List<string> {"c", "d"});
equations.Add(new List<string> {"d", "e"});

double[] values = {3.0, 4.0, 5.0, 6.0};

IList<IList<string>> queries = new List<IList<string>>();
queries.Add(new List<string> {"a", "e"});
queries.Add(new List<string> {"e", "b"});
queries.Add(new List<string> {"b", "d"});
queries.Add(new List<string> {"b", "b"});
queries.Add(new List<string> {"b", "h"});
queries.Add(new List<string> {"h", "h"});

var results = solution.CalcEquation(equations, values, queries);

foreach (var result in results)
{
	Console.Write(result + " ");
}

Console.WriteLine();