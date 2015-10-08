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
            // Ligne 1 : un entier **N** compris entre 1 et 1000 correspondant au nombre de hashtags du flux.  
            var nbLine = int.Parse(Console.ReadLine());

            // Lignes 2 à **N** + 1 : un hashtag Twitter.
            // Un hashtag est composé de lettres minuscules non accentuées précédées par le symbole #.
            var tags = (from i in Enumerable.Range(0, nbLine)
                         select Console.ReadLine())
                        .ToArray();

            var trends = new List<string>();
            
            for (int i = 0; i < nbLine; i++)
            {
                var trend = tags
                    .Skip(i)
                    .Take(60)
                    .GroupBy(x => x)
                    .Where(x => x.Count() >= 40);

                if (trend.Any())
                {
                    Console.WriteLine(trend.First().Key);
                    return;
                }
            }

            Console.WriteLine("Pas de trending topic");
        }
    }
}
