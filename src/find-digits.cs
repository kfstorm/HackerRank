using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var nCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < nCount; ++i)
        {
            var n = long.Parse(Console.ReadLine());
            var m = n;
            var count = 0;
            while (m > 0)
            {
                var x = m % 10;
                if (x != 0 && n % x == 0)
                {
                    ++count;
                }
                m = m / 10;
            }
            Console.WriteLine(count);
        }
    }
}