using System;
using System.Collections.Generic;

namespace AddUpTo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {
            1, 1, 2, 3, 4, 5, 1, 3, 0 };
            Console.WriteLine(SumOfTwo(nums, 2));
            Console.ReadLine();
        }

        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            int size = nums.Length;
            int amoutOfMatches = 0;

            Dictionary<int, bool> map = new Dictionary<int, bool>();
            for (int i = 0; i < size; i++)
            {
                map.Add(i, false);
            }
            for (int i = 0; i < size; i++)
            {
                if (map[i]) continue;
                for (int j = 0; j < size; j++)
                {
                    if (map[j]) continue;
                    if (i == j) continue;
                    if ((nums[i] + nums[j] == SumToFind) && (nums[i] == nums[j]))
                    {
                        amoutOfMatches++;
                        map[j] = true;
                    }

                }

            }
            return amoutOfMatches;
        }
    }
}
