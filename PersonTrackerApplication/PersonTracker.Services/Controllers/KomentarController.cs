using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using PersonTracker.Services.Models;
using PersonTracker.DataModel;
using System.Web.Http.Cors;

namespace PersonTracker.Services.Services
{
    [EnableCors("*", "*", "*", "PUT, POST, GET")]
    [RoutePrefix("api/Komentar")]
    public class KomentarController : ApiController
    {
        [HttpPost]
        [Route("RegisterCom")]
        public IHttpActionResult RegisterCom(string komentar, string ime, string prezime, string email, string idNestali=null, string idPrestupnik=null)
        {
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {

                    bool postoji = false;
                    int idKor = 0;
                    for (int i = 0; i < ctx.Korisnik.Count(); i++)
                    {
                        if (ctx.Korisnik.ToArray()[i].Email == email)
                        {
                            postoji = true;
                            idKor = ctx.Korisnik.ToArray()[i].idKorisnik;
                            break;
                        }
                    }

                    if (!postoji)
                    {
                        Korisnik k = new Korisnik()
                        {
                            Ime = ime,
                            Prezime = prezime,
                            Email = email
                        };
                        ctx.Korisnik.Add(k);
                        ctx.SaveChanges();
                        idKor = NadiKorisnika(email);
                    }

                    if (idNestali != null)
                    {
                        Komentar kom = new Komentar()
                        {
                            Tekst = komentar,
                            idKorisnik = idKor,
                            idNestali = Convert.ToInt32(idNestali)
                        };
                        ctx.Komentar.Add(kom);
                        ctx.SaveChanges();
                        return Ok();
                    }
                    else if (idPrestupnik != null)
                    {
                        Komentar kom = new Komentar()
                        {
                            Tekst = komentar,
                            idKorisnik = idKor,
                            idPrestupnik = Convert.ToInt32(idPrestupnik)
                        };
                        ctx.Komentar.Add(kom);
                        ctx.SaveChanges();
                        return Ok();
                    }
                    else return BadRequest("Komentar treba biti ili za nestalog ili za prestupnika.");
                    //naci korisnika po emailu i vratiti ID
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        private int NadiKorisnika(string email)
        {
            using (var ctx = new PersonTrackerDBEntities())
            {
                int idKorisnika = 0;
                for (int i = 0; i < ctx.Korisnik.Count(); i++)
                {
                    if (ctx.Korisnik.ToArray()[i].Email == email)
                    {
                        idKorisnika = ctx.Korisnik.ToArray()[i].idKorisnik;
                    }
                }
                return idKorisnika;
            }
        }


    }
}

