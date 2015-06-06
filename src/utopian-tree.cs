using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; ++i)
        {
            var x = int.Parse(Console.ReadLine());
            long result = 1;
            var @double = true;
            while (x > 0)
            {
                result = @double? result * 2 : result + 1;
                --x;
                @double = !@double;
            }
            Console.WriteLine(result);
        }
    }
}