using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BillCalculatoar
{
    public class Calculator
    {
        public Calculator(double newAmount, double oldAmount, IEnumerable<Scale> scales)
        {
            if (newAmount < oldAmount || 
                scales.Any(x => x is LastScale) == false
               )
                throw new ArgumentException();
            NewAmout = newAmount;
            OldAmout = oldAmount;
            BillScale = scales.ToList<Scale>();
        }
        public List<Scale> BillScale { get;}
        public double NewAmout { get; }
        public double OldAmout { get; set; }
        public double Amount
            => NewAmout - OldAmout;
        public LastScale GetLastScale() => BillScale.LastOrDefault(x => x is LastScale) as LastScale;
        public double GetTotalPrice()
        =>
            Amount.IF(
                (amt) => amt > getInScaleAmount(),
                () => getInScalePrice() + GetLastScale().Price * (Amount - getInScaleAmount()),
                () =>
                        {
                            var index = getIndexThatApplyRule();
                            return BillScale[index].Price * (Amount - getInScaleAmountTo(index)) +
                                   getInScaleAmountTo(index);
                        }
                );
        
        private double getInScaleAmount()
        => BillScale.Sum(x => x.Amount) - BillScale.Last().Amount;
        private double getInScalePrice()
        => BillScale.Where(x => (x is LastScale) == false).Sum(y => y.Amount * y.Price);


        //
        private double getInScaleAmount(IEnumerable<Scale> scales)
            => scales.Sum(x => x.Amount);
        private double getInScaleAmountTo(int index)
            => BillScale.GetRange(0, index).Sum(x => x.Amount);

        private double getInScalePriceTo(int index)
            => BillScale.GetRange(0, index).Sum(x => x.Amount * x.Price);

        private double getInScalePrice(IEnumerable<Scale> scales)
        => scales.Where(x => (x is LastScale) == false).Sum(y => y.Amount * y.Price);

        private int getIndexThatApplyRule()
        {
            for(int i = 0; i < BillScale.Count- 1; i++)
            {
                if (getInScaleAmount(BillScale.GetRange(0, i + 1)) > Amount)
                    return i;
            }
            return -1;
        }




    }
}
