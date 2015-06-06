// https://www.hackerrank.com/challenges/dorsey-thief

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        var parts = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        var n = int.Parse(parts[0]);
        var x = int.Parse(parts[1]);
        var a = new int[n];
        var v = new int[n];
        for (var i = 0; i < n; ++i)
        {
            parts = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            v[i] = int.Parse(parts[0]);
            a[i] = int.Parse(parts[1]);
        }
        
        var gain = new long[x + 1];
        var maxSold = 0;
        for (var i = 0; i < n; ++i)
        {
            for (var j = Math.Min(x - a[i], maxSold); j >= 0; --j)
            {
                if (gain[j] > 0 || j == 0)
                {
                    var sold = j + a[i];
                    var oldGain = gain[sold];
                    var newGain = gain[j] + v[i];
                    if (newGain > oldGain)
                    {
                        gain[sold] = newGain;
                        if (sold > maxSold)
                        {
                            maxSold = sold;
                        }
                    }
                }
            }
        }
        
        if (gain[x] > 0)
        {
            Console.WriteLine(gain[x]);
        }
        else
        {
            Console.WriteLine("Got caught!");
        }
    }
}
