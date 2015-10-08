using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        static bool[] map;
        static int w;
        static int l;
        static int h;

        static List<Tuple<int, int>> stack = new List<Tuple<int, int>>();

        static bool GetPosition(int x, int y)
        {
            return map[x * l + y];
        }

        static bool Process(int x, int y)
        {
            stack.Add(new Tuple<int, int>(x, y));

            if (x == w - 1 && y == l - 1)
                return true;

            // droite
            if (x < w && GetPosition(x + 1, y) && !stack.Any(s => s.Item1 == x + 1 && s.Item2 == y))
            {
                if (Process(x + 1, y))
                    return true;
            }

            // gauche
            if (x > 0 && GetPosition(x - 1, y) && !stack.Any(s => s.Item1 == x - 1 && s.Item2 == y))
            {
                if (Process(x - 1, y))
                    return true;
            }

            // bas
            if (y < l && GetPosition(x, y + 1) && !stack.Any(s => s.Item1 == x && s.Item2 == y + 1))
            {
                if (Process(x, y + 1))
                    return true;
            }

            // top
            if (y > 0 && GetPosition(x, y - 1) && !stack.Any(s => s.Item1 == x && s.Item2 == y - 1))
            {
                if (Process(x, y - 1))
                    return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            // Row 1 : 3 integers **W**, **L** and **H** space separated representing the width and length of the building, and the height that the water has reached.
            // **W** and **L** are between 2 and 50.
            // **H** is between 1 and 100,000.
            var infos = Console.ReadLine().Split(new[] { ' ' }).ToArray();

            w = int.Parse(infos[0]);
            l = int.Parse(infos[1]);
            h = int.Parse(infos[2]);

            // Row 2 to **W** + 1 : **L** integers between 1 and 100,000 separated by a space representing the height of the block for a given row.
            // The first value of row 2 is consequently the top left corner of the building and the last value of row **W** + 1 is the bottom right corner of the building.
            map = (from i in Enumerable.Range(0, w)
                   from line in Console.ReadLine().Split(new[] { ' ' }).ToArray()
                   select int.Parse(line) >= h)
                    .ToArray();

            Console.WriteLine(Process(0, 0) ? "YES" : "NO");
        }
    }
}
