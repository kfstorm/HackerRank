// TODO: TLD

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    static int FindAncestorOptimize(List<KeyValuePair<int, int>>[] parent, int x, int k)
    {
        var list = parent[x];
        if (list == null) return 0;
        
        var l = 0;
        var r = list.Count - 1;
        int mid;
        int midK;
        while (l < r)
        {
            mid = (l + r) / 2;
            midK = list[mid].Key;
            if (midK > k)
            {
                r = mid - 1;
            }
            else if (midK == k)
            {
                l = mid;
                r = mid;
            }
            else if (l != mid)
            {
                l = mid;
            }
            else if (list[r].Key <= k)
            {
                l = r;
            }
            else
            {
                r = l;
            }
        }
        
        var k2 = list[l];
        int y;
        if (l == list.Count - 1)
        {
            while (k2.Value != 0)
            {
                if (k2.Key * 2 > k) break;
                y = FindAncestorOptimize(parent, k2.Value, k2.Key);
                k2 = new KeyValuePair<int, int>(k2.Key * 2, y);
                list.Add(k2);
            }
        }
        
        if (k == k2.Key)
        {
            return k2.Value;
        }
        
        var yy = FindAncestorOptimize(parent, k2.Value, k - k2.Key);
        return yy;
    }
    static void Main(String[] args) {
        //  var z = 100000;
        //  Console.WriteLine(1);
        //  Console.WriteLine(z);
        //  for (var zz = 0; zz < z; ++zz)
        //  {
        //      Console.WriteLine("{0} {1}", zz + 1, zz);
        //  }
        //  Console.WriteLine(z - 1);
        //  for (var zz = 2; zz <= z; ++zz)
        //  {
        //      Console.WriteLine("2 {0} {1}", zz, zz - 1);
        //  }
        //  return;
        //  for (var zz = 2; zz <= z; ++zz)
        //  {
        //      Console.WriteLine(1);
        //  }
        //  return;
        var t = int.Parse(Console.ReadLine());
        string[] strs;
        int command;
        int x;
        int y;
        int k;
        for (var tt = 0; tt < t; ++tt)
        {
            var p = int.Parse(Console.ReadLine());
            var parent = new List<KeyValuePair<int, int>>[100001];
            for (var pp = 0; pp < p; ++pp)
            {
                strs = Console.ReadLine().Split(' ');
                x = int.Parse(strs[0]);
                y = int.Parse(strs[1]);
                parent[x] = new List<KeyValuePair<int, int>>(17);
                parent[x].Add(new KeyValuePair<int, int>(1, y));
            }
            
            var q = int.Parse(Console.ReadLine());
            for (var qq = 0; qq < q; ++qq)
            {
                strs = Console.ReadLine().Split(' ');
                command = int.Parse(strs[0]);
                switch (command)
                {
                    case 0:
                        y = int.Parse(strs[1]);
                        x = int.Parse(strs[2]);
                        parent[x] = new List<KeyValuePair<int, int>>(17);
                        parent[x].Add(new KeyValuePair<int, int>(1, y));
                        break;
                    case 1:
                        x = int.Parse(strs[1]);
                        parent[x] = null;
                        break;
                    case 2:
                        x = int.Parse(strs[1]);
                        k = int.Parse(strs[2]);
                        y = FindAncestorOptimize(parent, x, k);
                        Console.WriteLine(y);
                        break;
                }
            }
        }
    }
}