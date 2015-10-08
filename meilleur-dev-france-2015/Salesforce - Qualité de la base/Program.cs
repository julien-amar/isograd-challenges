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
            // Ligne 1 : un entier **N** compris entre 5 et 500 représentant le nombre de lignes dans l'extraction.  
            var nbLine = int.Parse(Console.ReadLine());

            // Ligne 2 : La liste des pays appartenant à votre zone représentée par une série de chaînes de caractères en minuscules non accentuées.
            // Les chaînes sont séparées par des ; (point-virgule).  
            var countries = Console.ReadLine().Split(new[] { ';' }).ToArray();

            // Ligne 3 à **N** + 2 : le nom, prénom, société, téléphone et pays du client séparés par des ; (point-virgule).
            // Les informations sont composées par : des lettres minuscules non accentuées, des chiffres et les caractères - et +.  
            var clients = (from i in Enumerable.Range(0, nbLine)
                         let a = Console.ReadLine().Split(new[] { ';' })
                         select new
                         {
                             Nom = a[0],
                             Prenom = a[1],
                             Societe = a[2],
                             Telephone = a[3],
                             Pays = a[4]
                         })
                        .ToArray();

            var doublons = clients.GroupBy(x => new { x.Nom, x.Prenom, x.Societe });
            var phoneWrongs = doublons.Select(x => x.First()).Where(x => !Regex.IsMatch(x.Telephone, @"^\+(\d{1,3})-(\d{9,11})$")).Count();
            var outZone = doublons.Select(x => x.First()).Where(x => !countries.Contains(x.Pays)).Count();

            Console.WriteLine("{0} {1} {2}", doublons.Where(x => x.Count() > 1).Count(), phoneWrongs, outZone);
        }
    }
}
