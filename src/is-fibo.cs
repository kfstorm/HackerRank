using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    static void IsFibo()
    {
        Console.WriteLine("IsFibo");
    }
    static void IsNotFibo()
    {
        Console.WriteLine("IsNotFibo");
    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var fib = new List<long>{0,1};
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; ++i)
        {
            var x = long.Parse(Console.ReadLine());
            if (x > fib.Last())
            {
                while (x > fib.Last())
                {
                    fib.Add(fib[fib.Count - 2] + fib[fib.Count - 1]);
                    if (fib.Last() == x)
                    {
                        IsFibo();
                        break;
                    }
                    else if (fib.Last() > x)
                    {
                        IsNotFibo();
                        break;
                    }
                }
            }
            else
            {
                var index = fib.BinarySearch(x);
                if (index >= 0)
                {
                    IsFibo();
                }
                else
                {
                    IsNotFibo();
                }
            }
        }
    }
}