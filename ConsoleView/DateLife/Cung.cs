using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateLife
{
    public class Cung
    {
        [JsonProperty("Latin")]
        public string Latin { get; set; }
        [JsonProperty("Viet")]
        public string Viet { get; set; }
        [JsonProperty("BeginDate")]
        public DateTime BeginDate { get; set; }
        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }
    }
}
