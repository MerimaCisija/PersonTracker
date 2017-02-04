using PersonTracker.DataModel;
using PersonTracker.Services.Models;
using PersonTracker.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PersonTracker.Services.Controllers
{
    [EnableCors("*", "*", "PUT, POST")]
    [RoutePrefix("api/Pretraga")]
    public class PretragaController : ApiController
    {
        [HttpGet]
        [Route("PretraziNestale")]
        public IHttpActionResult PretraziNestale(String parametarPretrage)
        {
            List<NestaliDO> listaNestalih = new List<NestaliDO>();
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    NestaliController nestContr = new NestaliController();
                    foreach (var item in ctx.Nestali.Where(model => model.Ime.ToLower().Contains(parametarPretrage) ||
                    model.Prezime.ToLower().Contains(parametarPretrage)))
                    {
                        NestaliDO nestali = new NestaliDO
                        {
                            idNestali = item.idNestali,
                            Ime = item.Ime,
                            Prezime = item.Prezime,
                            DatumNestanka = item.DatumNestanka,
                            Fotografija = item.Fotografija,
                            MjestoNestanka = item.MjestoNestanka,
                            GodinaRodenja = item.GodinaRodjenja,
                            Opis=item.Opis,
                            listaKomentara = nestContr.DobaviKomentare(item.idNestali),

                        };
                        listaNestalih.Add(nestali);
                    }
                }
                return Ok(listaNestalih);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("IzlistajNestale")]
        public IHttpActionResult IzlistajNestale()
        {
            List<NestaliDO> listaNestalih = new List<NestaliDO>();
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    NestaliController nestContr = new NestaliController();
                    foreach (var item in ctx.Nestali)
                    {
                        NestaliDO nestali = new NestaliDO
                        {
                            idNestali = item.idNestali,
                            Ime = item.Ime,
                            Prezime = item.Prezime,
                            DatumNestanka = item.DatumNestanka,
                            Fotografija = item.Fotografija,
                            MjestoNestanka = item.MjestoNestanka,
                            GodinaRodenja = item.GodinaRodjenja,
                            Opis = item.Opis,
                            listaKomentara = nestContr.DobaviKomentare(item.idNestali),

                        };
                        listaNestalih.Add(nestali);
                    }
                }
                return Ok(listaNestalih);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("PretraziPrestupnike")]
        public IHttpActionResult PretraziPrestupnike(String parametarPretrage)
        {
            List<PrestupnikDO> lista = new List<PrestupnikDO>();
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    PrestupnikController prestCont = new PrestupnikController();
                    foreach (var item in ctx.Prestupnik.Where(model => model.MjestoPrestupa.ToLower().Contains(parametarPretrage) ||
                    model.Opis.ToLower().Contains(parametarPretrage)))
                    {
                        PrestupnikDO prestupnik = new PrestupnikDO
                        {
                            idPrestupnik=item.idPrestupnik,
                            Opis=item.Opis,
                            Foto=item.Foto,
                            DatumPrestupa=item.DatumPrestupa,
                            MjestoPrestupa=item.MjestoPrestupa,
                            listaKomentara = prestCont.DobaviKomentare(item.idPrestupnik),
                        };
                        lista.Add(prestupnik);
                    }
                }
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("IzlistajPrestupnike")]
        public IHttpActionResult IzlistajPrestupnike()
        {
            List<PrestupnikDO> lista = new List<PrestupnikDO>();
            try
            {
                using (var ctx = new PersonTrackerDBEntities())
                {
                    PrestupnikController nestContr = new PrestupnikController();
                    foreach (var item in ctx.Prestupnik)
                    {
                        PrestupnikDO prestupnik = new PrestupnikDO
                        {
                            idPrestupnik = item.idPrestupnik,
                            Opis = item.Opis,
                            Foto = item.Foto,
                            DatumPrestupa = item.DatumPrestupa,
                            MjestoPrestupa = item.MjestoPrestupa,
                            listaKomentara = nestContr.DobaviKomentare(item.idPrestupnik),
                        };
                        lista.Add(prestupnik);
                    }
                }
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}