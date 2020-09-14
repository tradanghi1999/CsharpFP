using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft;
using Newtonsoft.Json;
using ExchangeConverter;
using Utils;
using Newtonsoft.Json.Linq;

namespace ClassConverter
{
    public class ObjConverter
    {
        public static string XMLstringToJsonString(string xmlString)
        => ExM.DoFuncWith(JsonConvert.SerializeObject, 
                () => {
                        var xml = new XmlDocument();
                        xml.LoadXml(xmlString);
                        return xml;
                        });
        
    }
    public class ExListConverter : ObjConverter
    {
       public static ExRateList  FromJsonToObject(string json)
       {
            return null;
       } 
    }
}
