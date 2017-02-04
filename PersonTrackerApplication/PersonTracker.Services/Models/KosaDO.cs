using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class KosaDO
    {
        [DataMember]
        public int idKosa { get; set; }
        [DataMember]
        public byte[] Layer { get; set; }
    }
}
