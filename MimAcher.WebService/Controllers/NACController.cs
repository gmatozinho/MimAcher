using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class NACController : Controller
    {
        public GestorDeNAC GestorDeNAC { get; set; }

        public NACController()
        {
            this.GestorDeNAC = new GestorDeNAC();
        }

        // GET: NAC
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC> listanacoriginal = this.GestorDeNAC.ObterTodosOsNAC();
            List<NAC> listanac = new List<NAC>();

            foreach (MA_NAC nc in listanacoriginal)
            {
                NAC nac = new NAC();

                nac.cod_nac = nc.cod_nac;
                nac.nomerepresentante = nc.nome_representante;

                listanac.Add(nac);
            }

            JsonResult jsonResult = Json(new
            {
                data = listanac
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<NAC> listanac)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listanac == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                int codigocadastrado = -1;

                foreach (NAC nc in listanac)
                {
                    MA_NAC nac = new MA_NAC();
                    nac.cod_usuario = nc.cd_usuario;
                    nac.cod_campus = nc.cod_campus;
                    nac.nome_representante = nc.nomerepresentante;
                    nac.telefone = nc.telefone;

                    this.GestorDeNAC.InserirNAC(nac);

                    codigocadastrado = nac.cod_nac;
                }

                jsonResult = Json(new
                {
                    codigo = codigocadastrado
                }, JsonRequestBehavior.AllowGet);
            }
            
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<NAC> listanac)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listanac == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                int codigocadastrado = -1;

                foreach (NAC nc in listanac)
                {
                    MA_NAC nac = new MA_NAC();
                    nac.cod_usuario = nc.cd_usuario;
                    nac.cod_campus = nc.cod_campus;
                    nac.nome_representante = nc.nomerepresentante;
                    nac.telefone = nc.telefone;

                    this.GestorDeNAC.AtualizarNAC(nac);

                    codigocadastrado = nac.cod_nac;
                }

                jsonResult = Json(new
                {
                    codigo = codigocadastrado
                }, JsonRequestBehavior.AllowGet);
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}