using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LaYumbaFP
{
    public class IOFactoryHandTest
    {
        public static string TestIOop()
        {
            string fileName = "hello.txt";
            return IOFactoryFP
                    .IOop<string,Exception, string>(File.ReadAllText, fileName)
                    .Match(e => "Error", str =>"OK");
        }

        public static string TestSafely()
        {
            return IOFactoryFP
                .Safely<string,Exception, string>(
                    File.ReadAllText,
                    e => e,
                    "hello.txt"
                )
                .Match(e => "Error", str => "OK");
        }
    }
}
