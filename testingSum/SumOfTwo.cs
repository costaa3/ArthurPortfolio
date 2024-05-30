public class Exercise
{
    public static int SumOfTwo(int[] nums, int SumToFind)
    {
        //if pair it can be 4 = 40 31 22 |  2 = 20 11 | 8 = 80 71 62 53 44  
        //if pair it can be 3 = 30 21 | 5 = 50 41 32 | 7 = 70 61 52 43 
        int totalFound = 0;
        var numberToFind = SumToFind / 2;
        if (nums.Where(it => it == numberToFind).Count() <= 1) return 0;
        SortedDictionary<int, int> result = new SortedDictionary<int, int>();
        var isPair = SumToFind % 2 == 0;
        for (int i = 0; i < SumToFind; i++)
        {
            if (result.TryGetValue(i, out int value))
            {
                var currentValue = result[i];
                result[i] = value++;
            }
            else result[i] = 1;
        }

        for (int i = 0, j = result.Count - 1; isPair ? i <= j : i < j; i++, j--)
        {
            var valueACount = result.ElementAt(i).Value;

            if (i == j) if (valueACount >= 2)
                {
                    totalFound++;
                    continue;
                }

            int item1 = result.ElementAt(i).Key;
            int item2 = result.ElementAt(j).Key;
            if (item1 + item2 == SumToFind) totalFound++;
            int item1Count = result.ElementAt(i).Key;
            //int item2 = result.ElementAt(j).Key;

        }



        return 1;
    }

}

