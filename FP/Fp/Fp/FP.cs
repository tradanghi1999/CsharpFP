using Either;
using Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Fp
{
    public static partial class FP
    {
        

        public static Either<L,R> Safely<L,R>(Func<R> f, Func<Exception, L> eF)
        {
            try
            {
                return new Either<L, R>(f());
            }
            catch(Exception e)
            {
                return new Either<L, R>(eF(e));
            }
        }    
        public static Func<T, R> ToFunc<T, R>(this Action<T> f)
            => (t) => { f(t); return default(R); };
            
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> list)
            => list.ToDictionary(x => x.Key, x => x.Value);
        
        public static R Using<R>(this Func<IDisposable, R> f, IDisposable disposable)
        {
            using (disposable) return f(disposable);
        }

        public static IEnumerable<Option<T>> ToOption<T>(this IEnumerable<T> ts)
            => ts.Select(t => t.ParseToOption());

        public static Option<T> ParseToOption<T>(this T t)
        {
            try
            {
                return new Some<T>(t);
            }
            catch
            {
                return new None();
            }
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
            => ts.Select(t => f(t));

        public static IEnumerable<R> MapWith<T, R>(this Func<T, R> f, IEnumerable<T> ts)
            => ts.Select(t => f(t));


        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
            => ts.SelectMany(t => f(t));

        public static IEnumerable<R> BindWith<T, R>(this Func<T, IEnumerable<R>> f, IEnumerable<T> ts)
            => ts.SelectMany(t => f(t));

        public static ISet<R> Map<T, R>(this ISet<T> ts, Func<T, R> f)
            => ts.Map(f).ToHashSet<R>();

        public static IDictionary<K, R> Map<K, V, R>(this IDictionary<K, V> dict, Func<V, R> f)
            => dict.Keys
            .Select(k => 
                        new KeyValuePair<K, R>(k, f(dict[k])))
            .ToDictionary<K, R>();


        public static Func<T1, R> Compose<T1, T2, R>(this Func<T1, T2> f1, Func<T2, R> f2)
            => (t1) => f2(f1(t1));

        // exercise

        public static Option<T> LookUp<T>(this IEnumerable<Option<T>> opts, T valueToLookup)
        {
            var optToLookup = valueToLookup.ParseToOption<T>();
            return opts.All(opt => opt is None) ?
            new None() :
            opts.Where(opt => opt is Some<T>)
                .Contains(optToLookup) ?
                opts.FirstOrDefault(opt => opt.Equals(optToLookup)) :
                    new None();
        }

        public static Option<T> LookUp<T>(this IEnumerable<Option<T>> opts, Predicate<T> predict)
        {
            //var optToLookup = valueToLookup.ParseToOption<T>();
            Func<bool> allFalse = () => false;
            Func<T, bool> rePredict = (t) => predict(t);
            Func<Option<T>, bool> optPredict = 
                (opt) => opt.Match<bool>(
                         allFalse,
                         rePredict
                     );

            return opts.All(opt => opt is None) ?
            new None() :
            opts.Where(opt => opt is Some<T>)
                .Any(optPredict) ?
                opts.FirstOrDefault(optPredict) :
                    new None();
        }



        public static T GetValue<T>(this Option<T> opt)
        =>    opt.Match<T>(
                () => default(T),
                t => t
                );
    }
}
