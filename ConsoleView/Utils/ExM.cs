using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ExM
    {
        public static IEnumerable<T> NForEach<T>(this IEnumerable<T> ts, Func<T,T> act)
        {
            List<T> list = new List<T>();
            foreach(var item in ts)
            {
                list.Add(act(item));
            }
            return list;
        }

        public static IEnumerable<T> NWhere<T>(this IEnumerable<T> ts, Predicate<T> pre)
        {
            List<T> list = new List<T>();
            foreach(var item in ts)
            {
                if(pre(item))
                {
                    list.Add(item);
                }    
            }
            return list;
        }    

        public static bool IsHigher(this int x, int y)
            => x > y;

        public static R Map<T, R>( this T t, Func<T, R> f) => f(t);
        //public static R Bind<T1<T2>, R>(this T1<T2> t, Func<T1<T2>, R> f)
    }
}
