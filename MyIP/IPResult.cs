using System;
using System.Runtime.Serialization;

namespace MyIP
{
    [DataContract]
    public class IPResult
    {
        [DataMember(Name = "ip")]
        public string IP
        {
            get; set;
        }
    }
}
