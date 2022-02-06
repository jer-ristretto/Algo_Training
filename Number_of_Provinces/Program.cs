using Number_of_Provinces;

var solution = new Solution();

int[][] input =
{
	new int[] {1, 0, 0, 1}, 
	new int[] {0, 1, 1, 0}, 
	new int[] {0, 1, 1, 1}, 
	new int[] {1, 0, 1, 1}
};

Console.WriteLine(solution.FindCircleNum(input));

