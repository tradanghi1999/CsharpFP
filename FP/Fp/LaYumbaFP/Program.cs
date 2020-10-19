using System;
using LaYumba;
using LaYumba.Functional;
using System.IO;

namespace LaYumbaFP
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("Hello World!");
            //

            Console.WriteLine(IOFactoryHandTest.TestIOop());
            Console.WriteLine(IOFactoryHandTest.TestSafely());
            //
            Console.ReadLine();
        }
    }
}
