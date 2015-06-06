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
            var regex = new Regex(@"<([\w_][\w\d_]*)(?:\s+([\w_][\w\d_]*)\s*=\s*['""][^>'""]*['""])*");
            var dict = new Dictionary<string, HashSet<string>>();
            for (var i = 0; i < n; ++i)
            {
                var input = Console.ReadLine();
                foreach (Match match in regex.Matches(input))
                {
                    var tag = match.Groups[1].Value;
                    HashSet<string> set;
                    if (!dict.TryGetValue(tag, out set))
                    {
                        set = new HashSet<string>();
                        dict[tag] = set;
                    }
                    foreach (Capture attribute in match.Groups[2].Captures)
                    {
                        set.Add(attribute.Value);
                    }
                }
            }

            foreach (var tag in dict.OrderBy(tag => tag.Key))
            {
                Console.WriteLine("{0}:{1}", tag.Key, string.Join(",", tag.Value.OrderBy(attribute=>attribute)));
            }
        }
    }
}
