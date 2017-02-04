using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class KomentarDO
    {
        [DataMember]
        public int idKomentar { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public Nullable<int> idPrestupnik { get; set; }
        [DataMember]
        public Nullable<int> idKorisnik { get; set; }
        [DataMember]
        public Nullable<int> idNestali { get; set; }
    }
}