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
            // Row 1 : an integer between 50,000 and 100,000 representing the opening balance.  
            var init = int.Parse(Console.ReadLine());

            // Row 2 : an integer **N** between 1 and 100 representing the number of transactions.  
            var nTour = int.Parse(Console.ReadLine());

            // Row 3 to **N** + 2 : an integer between -1000 and 1000 representing a transaction.
            var result = (from i in Enumerable.Range(0, nTour)
                          select int.Parse(Console.ReadLine()))
                        .ToArray();

            foreach (var turn in result)
            {
                init = init + turn;
            }

            Console.WriteLine(init);
        }
    }
}
