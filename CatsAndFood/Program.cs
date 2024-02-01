using System;
using System.Collections.Generic;

namespace CatsAndFood
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(NotHungryCats("O~~O~O~O F O~O~").ToString());
            Console.Read();
        }




        public static int NotHungryCats(string kitchen)
        {

            string catL = "O~";
            string catR = "~O";

            if (string.IsNullOrEmpty(kitchen))
            {
                return 0;
            }

            List<int> LMovingIndexes = new List<int>();
            List<int> RMovingIndexes = new List<int>();

            for (int i = 0; i < kitchen.Length - 1; i++)
            {
                string subStringToUse = kitchen.Substring(i, 2);
                if (subStringToUse.Equals(catR, StringComparison.OrdinalIgnoreCase))
                {
                    RMovingIndexes.Add(i);
                    i++;
                }
                else if (subStringToUse.Equals(catL, StringComparison.OrdinalIgnoreCase))
                {
                    LMovingIndexes.Add(i);
                    i++;
                }

            }

            var myPosition = kitchen.IndexOf("F");

            int catsNotGoingForFood = 0;

            foreach (int i in LMovingIndexes)
            {
                if (i < myPosition)
                {
                    catsNotGoingForFood++;
                }

            }
            foreach (int i in RMovingIndexes)
            {
                if (i > myPosition)
                {
                    catsNotGoingForFood++;
                }

            }

            return catsNotGoingForFood;

        }




    }
}
