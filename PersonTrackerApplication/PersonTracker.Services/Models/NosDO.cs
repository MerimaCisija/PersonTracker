using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class NosDO
    {
        [DataMember]
        public int idNos { get; set; }
        [DataMember]
        public byte[] Layer { get; set; }
    }
}
