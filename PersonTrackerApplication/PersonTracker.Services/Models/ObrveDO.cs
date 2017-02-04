using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class ObrveDO
    {
        [DataMember]
        public int idObrve { get; set; }
        [DataMember]
        public byte[] Layer { get; set; }
    }
}