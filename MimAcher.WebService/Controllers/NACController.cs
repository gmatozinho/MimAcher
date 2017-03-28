using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class NacController : Controller
    {
        public GestorDeNac GestorDeNac { get; set; }
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public NacController()
        {
            this.GestorDeNac = new GestorDeNac();
            this.GestorDeUsuario = new GestorDeUsuario();
        }

        // GET: Nac
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC> listanacoriginal = this.GestorDeNac.ObterTodosOsNacDeUsuariosAtivos();
            List<Nac> listanac = new List<Nac>();

            foreach (MA_NAC nc in listanacoriginal)
            {
                Nac nac = new Nac();

                nac.CodNac = nc.cod_nac;
                nac.Nomerepresentante = nc.nome_representante;

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
        public ActionResult Add(List<Nac> listanac)
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
                nac.cod_usuario = listanac[0].CdUsuario;
                nac.cod_campus = listanac[0].CodCampus;
                nac.nome_representante = listanac[0].Nomerepresentante;
                nac.telefone = listanac[0].Telefone;

                try
                {
                    if (this.GestorDeNac.InserirNacComRetorno(nac))
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
        public ActionResult Update(List<Nac> listanac)
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
                nac.cod_nac = listanac[0].CodNac;
                nac.cod_usuario = listanac[0].CdUsuario;
                nac.cod_campus = listanac[0].CodCampus;
                nac.nome_representante = listanac[0].Nomerepresentante;
                nac.telefone = listanac[0].Telefone;

                try
                {
                    if (this.GestorDeNac.AtualizarNacComRetorno(nac))
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
        public ActionResult Delete(List<Nac> listanac)
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

                nac.cod_nac = listanac[0].CodNac;
                
                try
                {
                    if (GestorDeNac.VerificarSeNacPorId(nac.cod_nac))
                    {
                        nac = GestorDeNac.ObterNacPorId(nac.cod_nac);

                        MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorId(nac.cod_usuario);

                        //Inativa o usuário associado a este Nac
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