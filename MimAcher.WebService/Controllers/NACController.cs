using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class NACController : Controller
    {
        public GestorDeNAC GestorDeNAC { get; set; }
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public NACController()
        {
            this.GestorDeNAC = new GestorDeNAC();
            this.GestorDeUsuario = new GestorDeUsuario();
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
                MA_NAC nac = new MA_NAC();
                nac.cod_usuario = listanac[0].cd_usuario;
                nac.cod_campus = listanac[0].cod_campus;
                nac.nome_representante = listanac[0].nomerepresentante;
                nac.telefone = listanac[0].telefone;

                try
                {
                    if (this.GestorDeNAC.InserirNACComRetorno(nac))
                    {
                        jsonResult = Json(new
                        {
                            codigo = nac.cod_nac
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
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
                MA_NAC nac = new MA_NAC();
                nac.cod_nac = listanac[0].cod_nac;
                nac.cod_usuario = listanac[0].cd_usuario;
                nac.cod_campus = listanac[0].cod_campus;
                nac.nome_representante = listanac[0].nomerepresentante;
                nac.telefone = listanac[0].telefone;

                try
                {
                    if (this.GestorDeNAC.AtualizarNACComRetorno(nac))
                    {
                        jsonResult = Json(new
                        {
                            codigo = nac.cod_nac
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        [HttpPost]
        public ActionResult Delete(List<NAC> listanac)
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
                MA_NAC nac = new MA_NAC();

                nac.cod_nac = listanac[0].cod_nac;
                
                try
                {
                    if (GestorDeNAC.VerificarSeNACPorId(nac.cod_nac))
                    {
                        nac = GestorDeNAC.ObterNACPorId(nac.cod_nac);

                        MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorId(nac.cod_usuario);

                        //Inativa o usuário associado a este NAC
                        usuario.cod_status = 2;

                        Boolean resultado = GestorDeUsuario.AtualizarUsuarioComRetorno(usuario);

                        if (resultado)
                        {
                            jsonResult = Json(new
                            {
                                codigo = nac.cod_nac
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            jsonResult = Json(new
                            {
                                codigo = -1
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}