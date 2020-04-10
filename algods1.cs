using System;
using System.Collections.Generic;

namespace algoDSProjekt1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Queue<int>> inputList = new List<Queue<int>>();
            //Lägger inputen från csv filen i en string array
            string path = @"C:\Users\elins\source\repos\aögpDSProjekt1.0\D2.txt";
            string[] lines = System.IO.File.ReadAllLines(path);


            //här anropas CreateList1 som konverterar strängen till en int lista som returneras och läggs till i stora inputlistan

            for (int i = 0; i < lines.Length; i++)
            {
                AddToQueue(inputList, lines, i);
            }

            //här skrivs listan ut
            foreach (Queue<int> intList in inputList)
            {
                foreach (int i in intList)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// metod för att konvertera strängen med input till en lista
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Queue<int> CreateFloorQueue(string s)
        {
            string[] floorString = s.Split(',');
            List<int> floor = new List<int>();
            Queue<int> floorQueue = new Queue<int>();
            floorQueue.Clear();
            for (int i = 0; i < floorString.Length; i++)
            {

                floor.Add(Convert.ToInt32(floorString[i]));

            }
            if (floor.Contains(-1) == false)
            {
                foreach (int val in floor)
                {

                    floorQueue.Enqueue(val);
                }
            }

            return floorQueue;
        }
        /// <summary>
        /// metod som tar emot en lista av int queue'er, input string arrayen, och indexet som det itereras i i den arrayen. Metoden avgör om i är 0-9, och anropar isf createfloorQueue, annars queuear den värderna i strängarna i rätt kö.
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="i"></param>
        /// <param name="lines"></param>
        /// <param name="linesIndex"></param>
        /// <returns></returns>
        public static List<Queue<int>> AddToQueue(List<Queue<int>> inputList, string[] lines, int linesIndex)
        {
            int i = linesIndex;
            if (i < 10)
            {

                inputList.Add(CreateFloorQueue(lines[i]));
            }
            if (i > 9 && i <= 20)
            {
                string[] floorString = lines[linesIndex].Split(',');
                List<int> floor = new List<int>();
                for (int j = 0; j < floorString.Length; j++)
                {

                    floor.Add(Convert.ToInt32(floorString[j]));

                }
                if (floor.Contains(-1) == false)
                {


                    foreach (int k in floor)
                    {
                        inputList[i - 10].Enqueue(k);
                    }
                }

            }
            if (i > 20)
            {
                i = i - 10;
                AddToQueue(inputList, lines, linesIndex);
            }
            return inputList;
        }
       


    }
}
