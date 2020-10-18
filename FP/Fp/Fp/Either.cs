using Fp;
using Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Either
{
    public class Either<L,R>
    {
        L l;
        R r;
        bool isLeft;
        public Either(L l)
        {
            this.l = l;
            isLeft = false;
        }
        public Either(R r)
        {
            this.r = r;
            isLeft = false;
        }
        public RR Match<RR>(Func<L, RR> leftF, Func<R, RR> rightF)
        => isLeft ? leftF(this.l) : rightF(this.r);

        public Either<L, RR> Map<RR>(Func<R, RR> f)
        => isLeft ? new Either<L, RR>(l) : new Either<L, RR>(f(r));

        public Either<L, RR> Bind<RR>(Func<R, Either<L, RR>> f)
            => this.Match(
                l => new Either<L, RR>(l),
                r => f(r)
                );

        public Option<R> ToOption()
            => isLeft ? new None() : r.ParseToOption();
    }
}
