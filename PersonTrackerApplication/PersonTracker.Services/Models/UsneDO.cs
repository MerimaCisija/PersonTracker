using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace PersonTracker.Services.Models
{
    [DataContract]
    public class UsneDO
    {      
        [DataMember]
        public int idUsne { get; set; }
        [DataMember]
        public byte[] Layer { get; set; }
    }
}
