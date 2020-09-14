using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace DateLife
{
    public class ClassConverter
    {
        public static string ToJson<T>(T t)
        => JsonConvert.SerializeObject(t);
    }
}
