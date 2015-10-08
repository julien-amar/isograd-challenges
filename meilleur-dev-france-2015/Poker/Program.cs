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
            // Ligne 1 : un entier entre 1 000 et 10 000 représentant la somme dont le joueur dispose au départ.  
            var init = int.Parse(Console.ReadLine());

            // Ligne 2 : un entier **N** entre 10 et 45 représentant le nombre de tours joués.  
            var nTour = int.Parse(Console.ReadLine());

            // Lignes 3 à N+2 : deux entiers positifs ou nuls séparés par un espace représentant X et Y tels que définis dans l'énoncé.  
            var result = (from i in Enumerable.Range(0, nTour)
                          select Console.ReadLine()
                                      .Split(new[] { ' ' })
                                      .Select(int.Parse)
                                      .ToArray());

            foreach (var turn in result)
            {
                init = init - turn[0] + turn[1];
            }

            Console.WriteLine(init);
        }
    }
}
