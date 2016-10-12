using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class NACCampusController : Controller
    {
        public GestorDeNAC GestorDeNACCampus { get; set; }

        public NACCampusController()
        {
            this.GestorDeNACCampus = new GestorDeNAC();
        }

        // GET: NACCampus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC_CAMPUS> listanaccampusoriginal = GestorDeNACCampus.ObterTodosOsNACCampus();
            List<NACCampus> listanaccampus = new List<NACCampus>();

            foreach(MA_NAC_CAMPUS nc in listanaccampusoriginal)
            {
                NACCampus naccampus = new NACCampus();

                naccampus.cod_nc = nc.cod_nc;
                naccampus.cod_us = nc.cod_us;
                naccampus.latitude = nc.geolocalizacao.Latitude;
                naccampus.longitude = nc.geolocalizacao.Longitude;
                naccampus.nomerepresentante = nc.nome_representante;

                listanaccampus.Add(naccampus);
            }

            JsonResult jsonResult = Json(new
            {
                data = listanaccampus
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}