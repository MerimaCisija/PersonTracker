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
    [RoutePrefix("api/Korisnik")]
    public class KorisnikController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(KorisnikDO Korisnik)
        {
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    Korisnik k = new Korisnik()
                    {
                        Ime = Korisnik.Ime,
                        Prezime = Korisnik.Prezime,
                        Email = Korisnik.Email
                    };

                    bool postoji = false;
                    for (int i = 0; i < ctx.Korisnik.Count(); i++)
                    {
                        if (ctx.Korisnik.ToArray()[i].Email == Korisnik.Email)
                        {
                            postoji = true;
                            break;
                        }
                    }
                    if (!postoji)
                    {
                        ctx.Korisnik.Add(k);
                        ctx.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return Ok();
                    }

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}