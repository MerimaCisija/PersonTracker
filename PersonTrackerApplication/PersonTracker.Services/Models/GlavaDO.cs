using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class GlavaDO
    {
        [DataMember]
        public int idGlava { get; set; }
        [DataMember]
        public byte[] Layer { get; set; }
    }
}