using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DateLife
{
    [DataContract]
    public class DateDataSource
    { 
       
        private int rootYear = 1999;
        

        [JsonProperty("RootYear")]
        public int RootYear => rootYear;
        [JsonProperty("RootCan")]
        public Can RootCan => Can.Ky;
        [JsonProperty("RootChi")]
        public Chi RootChi => Chi.Mao;

        private List<Cung> listCung = new List<Cung>()
        {
            new Cung(){ Latin = "Aries", Viet ="Bach Duong", BeginDate = new DateTime(2020, 03, 21), EndDate = new DateTime(2020,4,20)},
            new Cung(){ Latin = "Taurus", Viet ="Kim Nguu", BeginDate = new DateTime(2020, 04, 21), EndDate = new DateTime(2020,5,21)},
            new Cung(){ Latin = "Gemini", Viet ="Song Tu", BeginDate = new DateTime(2020, 5, 22), EndDate = new DateTime(2020,6,21)},
            new Cung(){ Latin = "Cancer", Viet ="Cu Giai", BeginDate = new DateTime(2020, 06, 22), EndDate = new DateTime(2020,7,22)},
            new Cung(){ Latin = "Leo", Viet ="Su Tu", BeginDate = new DateTime(2020, 07, 23), EndDate = new DateTime(2020,8,22)},
            new Cung(){ Latin = "Virgo", Viet ="Xu Nu", BeginDate = new DateTime(2020, 08, 23), EndDate = new DateTime(2020,9,23)},
            new Cung(){ Latin = "Libra", Viet ="Thien Binh", BeginDate = new DateTime(2020, 9, 24), EndDate = new DateTime(2020,10,23)},
            new Cung(){ Latin = "Scorpio", Viet ="Ho Cap", BeginDate = new DateTime(2020, 10, 24), EndDate = new DateTime(2020,11,22)},
            new Cung(){ Latin = "Sagittarius", Viet ="Nhan Ma", BeginDate = new DateTime(2020, 11, 23), EndDate = new DateTime(2020,12,21)},
            new Cung(){ Latin = "Capricornus", Viet ="Ma Ket", BeginDate = new DateTime(2020, 12, 22), EndDate = new DateTime(2021,1,20)},
            new Cung(){ Latin = "Aquarius", Viet ="Bao Binh", BeginDate = new DateTime(2021, 01, 21), EndDate = new DateTime(2021,2,19)},
            new Cung(){ Latin = "Pisces", Viet ="Song Ngu", BeginDate = new DateTime(2021, 02, 20), EndDate = new DateTime(2021,3,20)}

        };

        [JsonProperty("RootCungs")]
        public List<Cung> RootCungs => listCung;
    }
}
