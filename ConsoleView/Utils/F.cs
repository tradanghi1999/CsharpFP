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


        //public R Map<T1, T2, T3, R>(Func<T3, R> f1, Func<T1, T2, T3> f2, T1 t1,T2 t2)
        //    => f1(f2(t1, t2));

       










    }
}
