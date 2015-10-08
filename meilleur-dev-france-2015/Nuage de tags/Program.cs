using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ligne 1 : un entier **N** compris entre 15 et 800 représentant le nombre total de tags.
            var number = int.Parse(Console.ReadLine());

            // Ligne 2 à **N** + 1 : un tag du blog.
            var words = (from i in Enumerable.Range(0, number)
                          select Console.ReadLine())
                          .ToArray();

            var result = words
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .ToArray();

            foreach (var r in result)
                Console.WriteLine("{0} {1}", r.Key, r.Count());
        }
    }
}
