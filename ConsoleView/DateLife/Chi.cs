using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DateLife
{
    [DataContract]    
    public enum Chi
    {
        [EnumMember(Value="Ty")]
        Ty,
        [EnumMember(Value = "Suu")]
        Suu,
        [EnumMember(Value = "Dan")]
        Dan,
        [EnumMember(Value = "Mao")]
        Mao,
        [EnumMember(Value = "Thin")]
        Thin,
        [EnumMember(Value = "Ti")]
        Ti,
        [EnumMember(Value = "Ngo")]
        Ngo,
        [EnumMember(Value = "Mui")]
        Mui,
        [EnumMember(Value = "Than")]
        Than,
        [EnumMember(Value = "Dau")]
        Dau,
        [EnumMember(Value = "Tuat")]
        Tuat,
        [EnumMember(Value = "Hoi")]
        Hoi
    }
}
