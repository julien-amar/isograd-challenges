using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        static bool Process(char[][] map)
        {
            var update = false;

            for (int i = 0; i < map.Length; ++i)
                for (int j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j] != '.')
                    {
                        var connected = new[]
                        {
                            map[i-1][j],
                            map[i][j+1],
                            map[i+1][j],
                            map[i][j-1],
                        };

                        if (connected.Any(x => x == '.'))
                        {
                            map[i][j] = '1';
                            continue;
                        }

                        var shortest = connected.Where(x => x != '#').Min();

                        shortest++;

                        if (map[i][j] == '#')
                        {
                            map[i][j] = shortest;
                            update = true;
                            continue;
                        }

                        shortest = (char)Math.Min(map[i][j], shortest);

                        if (map[i][j] != shortest)
                        {
                            map[i][j] = shortest;
                            update = true;
                            continue;
                        }
                    }
                }

            return update;
        }

        static void Main(string[] args)
        {
            var stream = Console.In;

            // Ligne 1 : deux entiers **H** et **L** compris entre 3 et 40 séparés par un espace, indiquant respectivement la hauteur et la largeur de la carte.  
            var infos = stream.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();

            var h = infos[0];
            var w = infos[1];

            // Lignes 2 à **H** + 1 : les lignes de la carte représentées par des chaînes de **L** caractères.
            // Les caractères de la ligne sont soit :
            // - '.' (terre ferme)
            // - '#' (sable mouvant)
            var map = (from i in Enumerable.Range(0, h)
                       select stream.ReadLine().ToCharArray())
                       .ToArray();

            while (Process(map));

            var max = map.SelectMany(x => x)
                .Where(x => x != '.')
                .Max();

            Console.WriteLine("{0}", max - '0');
        }
    }
}
