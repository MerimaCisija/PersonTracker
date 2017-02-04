using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class SkicaDO
    {
        [DataMember]
        public int idSkica { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public Nullable<int> idGlava { get; set; }
        [DataMember]
        public Nullable<int> idCeljust { get; set; }
        [DataMember]
        public Nullable<int> idObrve { get; set; }
        [DataMember]
        public Nullable<int> idOci { get; set; }
        [DataMember]
        public Nullable<int> idNos { get; set; }
        [DataMember]
        public Nullable<int> idUsne { get; set; }
        [DataMember]
        public Nullable<int> idBrada { get; set; }
        [DataMember]
        public Nullable<int> idKosa { get; set; }
       
    }
}