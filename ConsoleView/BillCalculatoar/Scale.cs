using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BillCalculatoar
{
    public class Scale
    {
        protected Scale()
        {

        }
        public double Amount { get; protected set; }
        public double Price { get; protected set; }
        public static Scale GetScale(double amount, double price)
            => amount.IF<double, Scale>(
                (x) => x < 0,
                () => LastScale.GetLastScale(price),
                () => new Scale() { Amount = amount, Price = price }
             );
    }
    public class LastScale: Scale
    {
        private LastScale()
        =>    Amount = -1;
        public static LastScale GetLastScale(double price)
            => new LastScale() { Amount = -1, Price = price };
        
    }
}
