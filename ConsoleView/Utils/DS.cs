using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class DS
    {
        public class BMIds
        {
            public double Height { get; }
            public double Weight { get; }
            public BMIds(double height, double weight)
            {
                if(height <= 0)
                {
                    throw new ArgumentException();
                }
                if(weight < 0)
                {
                    throw new ArgumentException();
                }
                Height = height;
                Weight = weight;

            }
        }
    }
}
