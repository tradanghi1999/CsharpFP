using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DateLife
{
    public class DateLife
    {
        private DateDataSource source;
        public DateLife()
        {
            source = new DateDataSource();
        }

        public Can GetCan(int year)
        {
            return GetEnumYear<Can>(year, source.RootYear, source.RootCan);
        }

        public Chi GetChi(int year)
        {
            return GetEnumYear<Chi>(year, source.RootYear, source.RootChi);
        }

        public static List<TEnum> GetEnumList<TEnum>() where TEnum : Enum
        => ((TEnum[])Enum.GetValues(typeof(TEnum))).ToList();

        public static TEnum GetEnumYear<TEnum>(int year, int rootYear, TEnum rootEnum) where TEnum : Enum
        {
            var enumList = GetEnumList<TEnum>();
            var index = enumList.FindIndex(x => x.Equals(rootEnum));
            int yearSpace = year - rootYear;
            if(yearSpace > 0)
            {
                while(yearSpace > 0)
                {
                    if (index == enumList.Count - 1)
                        index = 0;
                    else
                        index++;
                    yearSpace--;
                }
            }
            else
            {
                while (yearSpace < 0)
                {
                    if (index == 0)
                        index = enumList.Count - 1;
                    else
                        index--;
                    yearSpace++;
                }
            }
            return enumList[index];

        }


    }
}
