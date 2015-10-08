using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoGrad
{
    class Program
    {
        static bool checkLuhn(string cardNumber)
        {
            var nums = cardNumber.Substring(0, 15)
                .Select(x=> int.Parse(x.ToString()))
                .ToArray();

            var sum = int.Parse(cardNumber.Last().ToString());

            for (int i = 0; i < nums.Length; i++)
            {
                var c = i % 2 == 0 ? nums[i] * 2 : nums[i];

                sum += ((c > 9) ? c - 9 : c);
            }

            return sum % 10 == 0;
        }

        static void Main(string[] args)
        {
            // Row 1 : an integer **N** between 1 and 1000 indicating the number of credit card numbers in the file.  
            var nTour = int.Parse(Console.ReadLine());

            // Row 2 to **N** + 1 : a string of 16 digits representing a credit card number.
            var result = (from i in Enumerable.Range(0, nTour)
                          select Console.ReadLine())
                        .ToArray();

            var valid = 0;

            foreach (var turn in result)
            {
                if (checkLuhn(turn))
                    valid++;
            }

            Console.WriteLine(valid);
        }
    }
}
