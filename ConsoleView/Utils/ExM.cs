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
        public static IEnumerable<T> NForEach<T>(this IEnumerable<T> ts, Func<T, T> act)
        {
            List<T> list = new List<T>();
            foreach (var item in ts)
            {
                list.Add(act(item));
            }
            return list;
        }
        public static IEnumerable<T> NWhere<T>(this IEnumerable<T> ts, Predicate<T> pre)
        {
            List<T> list = new List<T>();
            foreach (var item in ts)
            {
                if (pre(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }


        public static Func<T1, R> Map<T1, T2, R>(this Func<T1, T2> f1, Func<T2, R> f2) 
        => (x) => f2(f1(x));
      
        

        public static R Map<T, R>(this T t, Func<T, R> f) => f(t);
        //public static R Bind<T1<T2>, R>(this T1<T2> t, Func<T1<T2>, R> f)

        public static void With(this Action<object> actF, object obj) => actF(obj);
        public static void With(this Action<object> actF, Func<object> obj) => actF(obj());
        public static void With(this Action<object[]> actF, params Func<object>[] objs)
        {
            List<object> myObj = new List<object>();
            foreach (var obj in objs)
                myObj.Add(obj());
            actF(myObj.ToArray());
        }
        public static void With(this Action<object[]> actF, params object[] objs) => actF(objs);
        public static void With<T>(this Action<T> actF, T t) => actF(t);

        public static R With<T, R>(this Func<T, R> conF, T t) => conF(t);
        public static R DoFuncWith<T, R>(this Func<T, R> conF, T t) => conF(t);

        public static R DoFuncWith<T, R>(this Func<T, R> conF, Func<T> tF) => conF(tF());
        public static R IF<T, R>(this T t, Predicate<T> bolF, Func<R> truF, Func<R> falF)
            => bolF(t) ? truF() : falF();

        public static R IF<T, R>(this T t, Predicate<T> bolF, Func<bool,R> truF, Func<bool,R> falF)
            => bolF(t) ? truF(true) : falF(false);

        public static void IF<T>(this T t, Predicate<T> bolF, Action truF, Action falF)
        {
            if (bolF(t)) truF();
            else falF();
        }

        public static void IF<T>(this T t, Predicate<T> bolF, Action<bool> truF, Action<bool> falF)
        {
            if (bolF(t)) truF(true);
            else falF(false);
        }

        public static R TryConvert<T, R>(this T t, Func<T,R> conF)
        {
            try
            {
                return conF(t);
            }
            catch
            {
                return default(R);
            }
        }
    }
}
