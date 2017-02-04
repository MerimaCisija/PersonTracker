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
//using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using PersonTracker.Services.Models;
//using EventoAplikacija.Service.Providers;
//using EventoAplikacija.Service.Results;

using PersonTracker.DataModel;
using System.Web.Http.Cors;

namespace PersonTracker.Services.Services
{
    [EnableCors("*", "*", "PUT, POST")]
    [RoutePrefix("api/Skica")]
    public class SkicaController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(SkicaDO Skica)
        {
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    Skica s = new Skica()
                    {
                        idBrada = Skica.idBrada,
                        idCeljust = Skica.idCeljust,
                        idGlava = Skica.idGlava,
                        idKosa = Skica.idKosa,
                        idNos = Skica.idNos,
                        idObrve = Skica.idObrve,
                        idOci = Skica.idOci,
                        idUsne = Skica.idUsne,
                        Foto = Skica.Foto
                    };

                    ctx.Skica.Add(s);
                    ctx.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}