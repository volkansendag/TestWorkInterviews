using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCorrectPath
{
    class Program
    {
        public class point
        {
            public int x { get; set; }
            public int y { get; set; }

            public point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        public static List<point> pointList = new List<point>();

        static bool exists(point ptt)
        {
            return pointList.Any(p => p.x == ptt.x && p.y == ptt.y);
        }

        public static string CorrectPath(string str)
        {

            var arr = str.ToCharArray();
            var pt = new point(0,0);

            pointList.Add(pt);

            foreach (var item in arr)
            {
                if (item == 'r')
                {
                    pt.x++;
                }
                if (item == 'l')
                {
                    pt.x--;
                }
                if (item == 'u')
                {
                    pt.y--;
                }
                if (item == 'd')
                {
                    pt.y++;
                }
            }

            string result = "";

            foreach (var item in arr)
            {
                var newPath = item;
                if (newPath == '?')
                {
                    if (pt.x > 5 && !exists(new point(pt.x - 1, pt.y)))
                    {
                        newPath = 'l';
                        pt.x--;
                    }

                    if (pt.x < 5 && !exists(new point(pt.x + 1, pt.y)))
                    {
                        newPath = 'r';
                        pt.x++;
                    }

                    if (pt.y > 5 && !exists(new point(pt.x, pt.y-1)))
                    {
                        newPath = 'u';
                        pt.y--;
                    }

                    if (pt.y < 5 && !exists(new point(pt.x , pt.y+1)))
                    {
                        newPath = 'd';
                        pt.y++;
                    }
                }

                result += newPath;
            }

            char last = 'd';
            arr = result.ToCharArray();
            result = "";
            foreach (var item in arr)
            {
                var newPath = item;
                if (newPath == '?')
                {
                    if (last == 'd')
                    {
                        newPath = 'u';
                        last = 'u';
                    }
                    else
                    {
                        newPath = 'd';
                        last = 'd';
                    }
                }

                result += newPath;
            }

            return result;

        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine(CorrectPath(Console.ReadLine()));
            }
        }
    }
}