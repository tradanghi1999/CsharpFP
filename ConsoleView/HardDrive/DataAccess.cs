using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace HardDrive
{
    public class DataAccess
    {
        public static N Using<TDisp, N>(TDisp disposabe, Func<TDisp,N> f) where TDisp:IDisposable
        {
            using (disposabe) return f(disposabe);
        }

          

    }
}
