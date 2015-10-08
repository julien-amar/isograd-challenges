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
            // Row 1 : an integer between 1 and 100,000 representing the amount that you have to deliver.  
            var deliver = int.Parse(Console.ReadLine());

            // Row 2 : an integer **N** representing the number of types of notes that the cash dispenser can use.  
            var nbDeliver = int.Parse(Console.ReadLine());

            // Row 3 to **N** + 2 : an integer between 1 and 50,000 representing the face values of the notes that are available.
            // The notes are sorted ascendingly.  
            var delivers = (from i in Enumerable.Range(0, nbDeliver)
                            select int.Parse(Console.ReadLine()))
                            .OrderByDescending(x => x)
                            .ToArray();

            var tbl = new List<String>();

            foreach (var t in delivers)
            {
                var x = deliver / t;

                if (x != 0)
                {
                    tbl.Add(String.Format("{0} {1}", x, t));

                    deliver = deliver - (x * t);
                }
            }

            Console.WriteLine(String.Join(" ", tbl));
        }
    }
}
