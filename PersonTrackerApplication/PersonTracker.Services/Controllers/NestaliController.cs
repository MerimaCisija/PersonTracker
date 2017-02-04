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
using System.Data.SqlClient;

namespace PersonTracker.Services.Services
{
    [EnableCors("*", "*", "*", "PUT, POST, GET")]
    [RoutePrefix("api/Nestali")]
    public class NestaliController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(NestaliDO nestali)
        {
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    KorisnikController kc = new KorisnikController();
                    kc.Register(nestali.Korisnik);
                    var id = ctx.Korisnik.SqlQuery("SELECT * FROM dbo.Korisnik WHERE Email = @email", new SqlParameter("@email", nestali.Korisnik.Email));

                    Nestali n = new Nestali()
                    {
                        Ime = nestali.Ime,
                        Prezime = nestali.Prezime,
                        GodinaRodjenja = nestali.GodinaRodenja,
                        Fotografija = nestali.Fotografija,
                        DatumNestanka = nestali.DatumNestanka,
                        MjestoNestanka = nestali.MjestoNestanka,
                        Opis=nestali.Opis,
                        Spol=nestali.Spol,
                        idKorisnik = id.First().idKorisnik

                    };
                    ctx.Nestali.Add(n);
                    ctx.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("DobaviKomentare")]
        public List<String> DobaviKomentare(int idNest)
        {
            List<String> listaKomentara = new List<string>();
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    for (int i = 0; i < ctx.Komentar.Count(); i++)
                    {
                        if (ctx.Komentar.ToArray()[i].idNestali == idNest)
                        {
                            listaKomentara.Add(ctx.Komentar.ToArray()[i].Tekst);
                        }
                    }

                }
                return listaKomentara;
            }
            catch (Exception e)
            {

            }
            return listaKomentara;
        }

    }




}