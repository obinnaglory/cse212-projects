public static class ArraySelector
{
    // Steps to solve MultiplesOf(start, count):
// 1. Create a new array of type double with length equal to 'count'.
// 2. Use a for loop from i = 0 up to count-1.
// 3. For each index i, calculate (start * (i+1)).
//    - Example: start=3, i=0 → 3*1=3; i=1 → 3*2=6, etc.
// 4. Store the result in the array at position i.
// 5. After the loop finishes, return the array.

    
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }


    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new int[select.Length];
        var l1Idx = 0;
        var l2Idx = 0;
        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
                result[i] = list1[l1Idx++];
            else
                result[i] = list2[l2Idx++];
        }
        return result;
    }
    public static double[] MultiplesOf(double start, int count)
{
    // Step 1: Create array
    double[] multiples = new double[count];

    // Step 2: Loop through indices
    for (int i = 0; i < count; i++)
    {
        // Step 3: Calculate multiple
        multiples[i] = start * (i + 1);
    }

    // Step 4: Return array
    return multiples;
}
    // Steps to solve RotateListRight(data, amount):
// 1. The list needs to be rotated to the right by 'amount'.
// 2. Find the split point: data.Count - amount.
//    - Example: data.Count=9, amount=3 → split=6.
// 3. Use GetRange to slice the list into two parts:
//    - First part: data.GetRange(split, amount) → the last 'amount' elements.
//    - Second part: data.GetRange(0, split) → the remaining elements at the front.
// 4. Create a new list and add the first part, then add the second part.
// 5. Return the new list.
    public static List<int> RotateListRight(List<int> data, int amount)
{
    // Step 1: Find split point
    int split = data.Count - amount;

    // Step 2: Slice into two parts
    List<int> lastPart = data.GetRange(split, amount);
    List<int> firstPart = data.GetRange(0, split);

    // Step 3: Combine into new list
    List<int> rotated = new List<int>();
    rotated.AddRange(lastPart);
    rotated.AddRange(firstPart);

    // Step 4: Return rotated list
    return rotated;
}

}
