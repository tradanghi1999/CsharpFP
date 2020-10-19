using System;
using System.Collections.Generic;
using System.Text;
using LaYumba;
using LaYumba.Functional;

namespace LaYumbaFP
{
    public static class IOFactoryFP
    {
        public static Either<L, R> Safely<L, R>(this Func<R> f, Func<Exception, L> eF)
        {
            try
            {
                return f();
            }
            catch (Exception e)
            {
                return eF(e);
            }
        }
        public static Either<L, R> Safely<T,L, R>(this Func<T,R> f, Func<Exception, L> eF, T t)
        {
            try
            {
                return f(t);
            }
            catch (Exception e)
            {
                return eF(e);
            }
        }
        public static Either<E, R> IOop<T,E, R>(this Func<T,R> f, T t) where E: Exception
        {
            try
            {
                //return Either nhung hinh thuc la ham f(t)
                return f(t);
            }
            catch(Exception e)
            {
                return (E)e;
            }
        }

        public static Either<Exception, R> IOop<T, R>(this T t, Func<T, R> f)
        {
            try
            {
                //return Either nhung hinh thuc la ham f(t)
                return f(t);
            }
            catch (Exception e)
            {
                return e;
            }
        }


    }
}
