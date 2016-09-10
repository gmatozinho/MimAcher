using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class NACCampusController : Controller
    {
        public GestorDeNACCampus GestorDeNACCampus { get; set; }

        public NACCampusController()
        {
            this.GestorDeNACCampus = new GestorDeNACCampus();
        }

        // GET: NACCampus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC_CAMPUS> listanaccampus = GestorDeNACCampus.ObterTodosOsNACCampus();

            JsonResult jsonResult = Json(new
            {
                data = listanaccampus
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}