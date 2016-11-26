using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.HttpPostedFileBase;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.WebService.Controllers
{
    public class ImagemParticipanteController : Controller
    {
        public GestorDeImagemDeParticipante GestorDeImagemDeParticipante { get; set; }

        public ImagemParticipanteController()
        {
            this.GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
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

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                //Forma 1			
                MemoryStream target = new MemoryStream();
                arquivo.InputStream.CopyTo(target);

                imagem_participante.cod_participante = codigo_participante;
                imagem_participante.imagem = "";

                GestorDeImagemDeParticipante.InserirImagem(imagem_participante);
                                
                Directory.CreateDirectory(@"\\w7v\AspNetSites\mimacherforms\App\Upload" + @"\" + numeroId.Value.ToString());
                

                anexo.arquivo = target.ToArray();


                anexo.ds_anexo = ds_anexo;
                anexo.cd_apo = cd_apo;
                anexo.MIME = arquivo.ContentType;
                anexo.tipo = System.IO.Path.GetExtension(arquivo.FileName).Substring(1);

                this.GestorDeAnexo.InserirAnexo(anexo);
            }

            

            //Compara para ver se já existe um anexo para aquele APO
            if (this.GestorDeAnexo.VerificaSeAnexoDeUmApoExiste(cd_apo))
            {
                return Json(new
                {
                    message = "Já existe um anexo para esta APO",
                    success = false
                });
            }
            else
            {
                //Forma 1			
                MemoryStream target = new MemoryStream();
                arquivo.InputStream.CopyTo(target);
                anexo.arquivo = target.ToArray();

                anexo.ds_anexo = ds_anexo;
                anexo.cd_apo = cd_apo;
                anexo.MIME = arquivo.ContentType;
                anexo.tipo = System.IO.Path.GetExtension(arquivo.FileName).Substring(1);

                this.GestorDeAnexo.InserirAnexo(anexo);
            }
            
            return Json(new
            {
                data = Mapper.Map<APOWeb_Anexo, DTO.APOWeb_Anexo>(anexo),
                //data = [ anexorecuperado.ds_anexo, anexorecuperado.arquivo ],
                //data = this.GestorDeAnexo.ObterAnexoPorId(anexo.cd_anexo),  
                message = "Registro inserido com sucesso",
                success = true
            });

            //return RedirectToAction("login", "login");
        }
    }
}