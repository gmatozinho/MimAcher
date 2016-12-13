using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using System;

namespace MimAcher.WebService.Controllers
{
    public class ImagemParticipanteController : Controller
    {
        public GestorDeImagemDeParticipante GestorDeImagemDeParticipante { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }

        public ImagemParticipanteController()
        {
            this.GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
            this.GestorDeParticipante = new GestorDeParticipante();
        }

        // GET: ImagemUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_IMAGEM_PARTICIPANTE> listaimagemparticipante = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();

            JsonResult jsonResult = Json(new
            {
                data = listaimagemparticipante
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Upload(System.Web.HttpPostedFileBase arquivo, int codigoParticipante)
        {   
            MA_IMAGEM_PARTICIPANTE imagemParticipante = new MA_IMAGEM_PARTICIPANTE();

            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (arquivo == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (GestorDeParticipante.VerificarSeParticipanteExiste(codigoParticipante)){

                    
                    MemoryStream target = new MemoryStream();
                    arquivo.InputStream.CopyTo(target);
                                        
                    //Define o nome do diretório para a imagem do participante
                    String diretorio = @"\\w7v\AspNetSites\mimacherforms\App\Upload" + @"\" + codigoParticipante.ToString();

                    //Cria o diretório para o participante
                    Directory.CreateDirectory(diretorio);

                    //Cria o nome do arquivo a partir do código do participante
                    String nomearquivo = codigoParticipante.ToString() + "." + arquivo.GetType();

                    //Salva o arquivo no diretório
                    arquivo.SaveAs(Path.Combine(diretorio, nomearquivo));

                    //Configura o registro de imagem de participante para ser inserido no banco de dados
                    imagemParticipante.cod_participante = codigoParticipante;
                    imagemParticipante.imagem = diretorio + nomearquivo;

                    //Salva o registro de imagem do participante
                    GestorDeImagemDeParticipante.InserirImagem(imagemParticipante);

                    jsonResult = Json(new
                    {
                        codigo = codigoParticipante
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

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}