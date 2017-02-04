using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PersonTracker.Services.Models
{
    [DataContract]
    public class KorisnikDO
    {
        [DataMember]
        public int idKorisnik { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string Email { get; set; }


    }
}