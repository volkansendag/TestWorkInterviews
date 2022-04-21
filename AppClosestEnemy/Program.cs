using System;
using System.Collections.Generic;

namespace AppClosestEnemy
{
    class Program
    {
        public static int ClosestEnemy(int[] arr)
        {
            List<int> birler = new List<int>();
            List<int> ikiler = new List<int>();

            int min = arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] ==1)
                {
                    birler.Add(i);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 2)
                {
                    ikiler.Add(i);
                }
            }

            for (int i = 0; i < birler.Count; i++)
            {
                int bir = birler[i];
                for (int ii = 0; ii < ikiler.Count; ii++)
                {
                    int iki = ikiler[ii];
                    int fark = Math.Abs(bir - iki);

                    if(fark < min)
                    {
                        min = fark;
                    }
                }
            }

            //Console.WriteLine(string.Join(" ", birler));
            //Console.WriteLine(string.Join(" ", ikiler));

            return min;
        }


        static void Main()
        {
            // keep this function call here
            Console.WriteLine(ClosestEnemy(new int[] { 1, 0, 0, 0, 2, 2, 2 }));
            Console.WriteLine(ClosestEnemy(new int[] { 2, 0, 0, 0, 2, 2, 1, 0 }));

            Console.ReadKey();
        }
    }
}
