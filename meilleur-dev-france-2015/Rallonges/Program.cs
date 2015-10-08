using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ligne 1 : un entier **N** compris entre 1 et 1000 représentant le nombre de rallonges.  
            var nbLine = int.Parse(Console.ReadLine());

            // Lignes 2 à **N** + 1 : une chaîne de 3 caractères et un entier compris entre 1 et 50 séparés par un espace.
            // La chaîne correspond au type de prise : M-M, F-M, M-F ou F-F et l'entier correspond à sa longueur.
            var rallonges = (
                        from i in Enumerable.Range(0, nbLine)
                        let line = Console.ReadLine()
                        let infos = line.Split(new[] { ' ' })
                        select new
                        {
                            Type = infos.First(),
                            Length = int.Parse(infos.Last())
                        })
                        .OrderByDescending(x => x.Length)
                        .ToArray();

            var mf = rallonges.Where(x => x.Type == "M-F");
            var fm = rallonges.Where(x => x.Type == "F-M");

            var mm = rallonges.Where(x => x.Type == "M-M");
            var ff = rallonges.Where(x => x.Type == "F-F");

            var takeSame = Math.Min(mm.Count(), ff.Count());

            var length =
                mf.Sum(x => x.Length) +
                fm.Sum(x => x.Length) +
                mm.Take(takeSame).Sum(x => x.Length) +
                ff.Take(takeSame).Sum(x => x.Length);

            Console.WriteLine("{0}", length);
        }
    }
}
