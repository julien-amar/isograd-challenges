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
            // Row 1: an integer **N** representing the total number of people that enter the building over one day.
            var nTour = int.Parse(Console.ReadLine());

            // Row 2 to **N** + 1: 2 integers between 0 and 24, separated by a space, representing the hours of arrival and departure of every employee.
            var employees = (from i in Enumerable.Range(0, nTour)
                            select Console.ReadLine()
                                     .Split(new[] { ' ' })
                                     .Select(int.Parse)
                                     .ToArray()
                                     )
                                     .ToArray();

            var res =   from h in Enumerable.Range(0, 24)
                        select new
                        {
                            nbEmployee = employees.Where(x => x[0] <= h && h < x[1]).Count(),
                            hour = h
                        };

            var r2 = res.GroupBy(x => x.nbEmployee)
                .OrderByDescending(x => x.Key)
                .First()
                .OrderBy(x => x.hour)
                .Select(x => x.hour.ToString())
                .ToArray();

            Console.WriteLine(String.Join(" ", r2));
        }
    }
}
