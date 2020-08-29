using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlClient
{
    public class ConnectionHelper
    {
        public R Connect<R>(string connString, Func<IDbConnection, R> f)
        {
            using(var conn = new SqlConnection(connString))
            {
                conn.Open();
                return f(conn);
            }    
        }

        public N Connectv2<N>(string connString, Func<IDbConnection, N> f)
            => Using(new SqlConnection(connString), 
                conn => { conn.Open(); return f(conn);});

        public static N Using<TDisp, N>(TDisp disposable, Func<TDisp, N> f) where TDisp:IDisposable
        {
            using (disposable) return f(disposable);
        }    
    }


}
