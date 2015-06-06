using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var regex1 = new Regex("^hackerrank.*$");
            var regex2 = new Regex("^.*hackerrank$");
            for (var i = 0; i < n; ++i)
            {
                var input = Console.ReadLine();
                if (regex1.Match(input).Success)
                {
                    if (regex2.Match(input).Success)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(1);
                    }
                }
                else if (regex2.Match(input).Success)
                {
                    Console.WriteLine(2);
                }
                else
                {
                    Console.WriteLine(-1);
                }
            }
        }
    }
}
