using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class PrestupnikDO
    {
        [DataMember]
        public int idPrestupnik { get; set; }
        [DataMember]
        public Nullable<int> idKorisnik { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public string MjestoPrestupa { get; set; }
        [DataMember]
        public string Foto { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DatumPrestupa { get; set; }
        [DataMember]
        public virtual KorisnikDO Korisnik { get; set; }
        [DataMember]
        public List<String> listaKomentara { get; set; }
    }
}