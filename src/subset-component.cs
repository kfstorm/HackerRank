using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        var n = int.Parse(Console.ReadLine());
		var d = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => ulong.Parse(i)).ToArray();
		
		var result = 64;
		var sets = new List<ulong[]>((int)Math.Pow(2, n));
		sets.Add(Enumerable.Range(0, 64).Select(i => 1UL << i).ToArray());
		var newSet = new List<ulong>(64);
		for (var i = 0; i < n; ++i)
		{
			var count = sets.Count;
			for (var j = 0; j < count; ++j)
			{
				newSet.Clear();
				var merged = d[i];
				foreach (var x in sets[j])
				{
					if ((x & d[i]) != 0UL)
					{
						merged |= x;
					}
					else
					{
						newSet.Add(x);
					}
				}
				if (merged != 0UL)
				{
					newSet.Add(merged);
				}
				result += newSet.Count;
				if (i < n - 1)
				{
					sets.Add(newSet.ToArray());
				}
			}
		}
		
		Console.WriteLine(result);
    }
}