using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeAPI
{
    internal class DataAPI
    {
        string url = "https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=68";

        public static N Using<TDisp, N>(TDisp disposable, Func<TDisp, N> f) where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }


        public N Connect<N>(string url, Func<HttpWebResponse, N> f) =>
            Using(  WebRequest.CreateHttp(url).GetResponse(), 
                    conn => f((HttpWebResponse)conn));



        //
        public string ReadString(HttpWebResponse response)
            => Using(new StreamReader(
                                        response.GetResponseStream(), 
                                        Encoding.UTF8
                                     ), 
                     stream => stream.ReadToEnd());


        public string GetJson(string url)
            => Connect(url, ReadString);


        //

        public byte[] ReadBytes(HttpWebResponse response)
            => Using(new MemoryStream(), 
                mStream => { 
                                response.GetResponseStream().CopyTo(mStream); 
                                return mStream.ToArray(); 
                });


        public byte[] GetBytes(string url)
        => Connect(url, ReadBytes);


        internal string GetExchangeXMLstring()
        => Connect(url, ReadString);

    }
}
