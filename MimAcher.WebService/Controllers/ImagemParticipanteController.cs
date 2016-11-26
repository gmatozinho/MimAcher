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
        public ActionResult Upload(System.Web.HttpPostedFileBase arquivo, int codigo_participante)
        {   
            MA_IMAGEM_PARTICIPANTE imagem_participante = new MA_IMAGEM_PARTICIPANTE();

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
                if (GestorDeParticipante.VerificarSeParticipanteExiste(codigo_participante)){

                    
                    MemoryStream target = new MemoryStream();
                    arquivo.InputStream.CopyTo(target);
                                        
                    //Define o nome do diretório para a imagem do participante
                    String diretorio = @"\\w7v\AspNetSites\mimacherforms\App\Upload" + @"\" + codigo_participante.ToString();

                    //Cria o diretório para o participante
                    Directory.CreateDirectory(diretorio);

                    //Cria o nome do arquivo a partir do código do participante
                    String nomearquivo = codigo_participante.ToString() + "." + arquivo.GetType();

                    //Salva o arquivo no diretório
                    arquivo.SaveAs(Path.Combine(diretorio, nomearquivo));

                    //Configura o registro de imagem de participante para ser inserido no banco de dados
                    imagem_participante.cod_participante = codigo_participante;
                    imagem_participante.imagem = diretorio + nomearquivo;

                    //Salva o registro de imagem do participante
                    GestorDeImagemDeParticipante.InserirImagem(imagem_participante);

                    jsonResult = Json(new
                    {
                        codigo = codigo_participante
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