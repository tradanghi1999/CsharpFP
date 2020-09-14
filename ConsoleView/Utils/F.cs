using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class F
    {
        public Predicate<bool> bulPredicate = x => !x;

        public Func<double, double, double> bmiCalculator = (height, weight) => weight / (height * height);

        public Func<double, string> bmiEval = (bmiRes) =>
            bmiRes >= 25 ? "Overweight" : bmiRes >= 18.5 ? "Healthy" : "Underweight";

        public string doRep(int x,int n)
        {
            var y = "";
            if (n == 0)
                return "";
            else
            {
                y = doRep(x, n - 1);
                Console.WriteLine(y);
                y += x;
                return y;
            }    
 
        }


        

    }
}
