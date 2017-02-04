using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class NestaliDO
    {
        [DataMember]
        public int idNestali { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public Nullable<int> GodinaRodenja { get; set; }
        [DataMember]
        public string Fotografija { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DatumNestanka { get; set; }
        [DataMember]
        public string MjestoNestanka { get; set; }
        [DataMember]
        public string Opis { get; set; }
        [DataMember]
        public bool Spol { get; set; }
        [DataMember]
        public List<String> listaKomentara { get; set; }
        [DataMember]
        public Nullable<int> idKorisnik { get; set; }
        [DataMember]
        public virtual KorisnikDO Korisnik { get; set; }
    }
}