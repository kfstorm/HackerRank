//https://www.hackerrank.com/challenges/and-product

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var t = int.Parse(Console.ReadLine());
        for (var x = 0; x < t; ++x)
        {
            var line = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            ulong a = ulong.Parse(line[0]);
            ulong b = ulong.Parse(line[1]);
            
            ulong answer = 0;
            ulong c = a;
            while (c > 0)
            {
                ulong d = (~c + 1) & c;
                if (d == 0x8000000000000000UL)
                {
                    answer |= d;
                }
                else
                {
                    ulong e = (a | (d * 2 - 1)) + 1;
                    if (e == 0 || e > b)
                    {
                        answer |= d;
                    }
                }
                c -= d;
            }
            Console.WriteLine(answer);
        }
    }
}