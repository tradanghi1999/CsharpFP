using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ls = new List<int>() { 1, 2, 3, 4, 5 };
            Predicate<int> isEven = (i) => i % 2 == 0;

            Console.WriteLine(ls.ToOption<int>().LookUp<int>(1));
            Console.WriteLine(ls.ToOption().LookUp<int>(isEven));


            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(0, "2");
            dict.Add(1, "0");

            var newDict =   dict.Map((str) =>
                               {
                                   return int.Parse(str) + 3;
                               });


            int x = 0;
            newDict.TryGetValue(0,out x);
            Console.WriteLine(x);

            Console.ReadLine();
        }
    }
}
