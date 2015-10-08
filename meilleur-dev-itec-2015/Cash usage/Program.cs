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
            // Row 1 : an integer **N** between 1 and 1000 indicating the number of entries in the log file.  
            var nbEntry = int.Parse(Console.ReadLine());

            // Row 2 to **N** + 1 : a string of 8 alphanumeric characters and an integer number between 10 and 1000 separated by a space.
            // They represent the identifier of the cash dispenser and the amount withdrawn.
            var delivers = (from i in Enumerable.Range(0, nbEntry)
                            let line = Console.ReadLine().Split(new[] { ' ' }).ToArray()
                            select new {
                                id = line[0],
                                amount = int.Parse(line[1])
                            })
                            .GroupBy(x => x.id)
                            .Select(x => new
                            {
                                id = x.Key,
                                amount = x.Select(e => e.amount).Sum(),
                            })
                            .OrderByDescending(x => x.amount)
                            .ThenBy(x => x.id)
                            .Take(10)
                            .Select(x => x.id)
                            .ToArray();

            Console.WriteLine(String.Join(" ", delivers));
        }
    }
}
