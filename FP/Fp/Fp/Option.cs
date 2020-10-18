using Either;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Option
{
    public struct None
    {
        internal static readonly None Default = new None();
    }
    public struct Some<T>
    {
        internal T Value { get; }
        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentException();
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Some<T>)
                return ((Some<T>)obj).Value.Equals(this.Value);
            return false;
        }

         
    }
    public struct Option<T>
    {
        readonly bool isSome;
        readonly T value;
        private Option(T value)
        {
            this.isSome = true;
            this.value = value;
        }
        public bool IsSome
            => isSome;

        public static implicit operator Option<T>(Option.None _)
            => new Option<T>();

        public static implicit operator Option<T>(Option.Some<T> some)
            => new Option<T>(some.Value);
        public static implicit operator Option<T>(T value)
        {
            if (value == null)
                return new None();
            return new Some<T>(value);
        }

        public override bool Equals(object obj)
        {
            if(obj is Option<T>)
            {
                var opt = (Option<T>)obj;
                return opt.value.Equals(this.value);
            }
            return false;
             
        }
        public R Match<R>(Func<R> None, Func<T, R> Some)
            => isSome ? Some(value) : None();

        public Either<L, R> ToEither<L, R>(Func<Option<T>, R> f, Func<L> noF)
            => isSome ? new Either<L, R>(f(this)) : new Either<L, R>(noF());

    }
}
