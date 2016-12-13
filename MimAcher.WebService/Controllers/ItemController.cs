using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class ItemController : Controller
    {
        public GestorDeItem GestorDeItem { get; set; }

        public ItemController()
        {
            this.GestorDeItem = new GestorDeItem();
        }

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ITEM> listaitemoriginal = this.GestorDeItem.ObterTodosOsItems();
            List<Item> listaitem = new List<Item>();

            foreach (MA_ITEM it in listaitemoriginal)
            {
                Item item = new Item();

                item.cod_item = it.cod_item;
                item.nome = it.nome;

                listaitem.Add(item);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaitem
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<Item> listaitem)
        {
            JsonResult jsonResult;
            int codigocadastrado = 0;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaitem == null)
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
                foreach (Item it in listaitem)
                {
                    MA_ITEM item = new MA_ITEM();
                    item.nome = it.nome;

                    this.GestorDeItem.InserirItem(item);

                    codigocadastrado = item.cod_item;
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
        public ActionResult Update(List<Item> listaitem)
        {
            JsonResult jsonResult;
            int codigocadastrado = 0;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaitem == null)
            {
                jsonResult = Json(new
                {
                    codigo = codigocadastrado
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (Item it in listaitem)
            {
                MA_ITEM item = new MA_ITEM();
                item.cod_item = it.cod_item;
                item.nome = it.nome;

                this.GestorDeItem.InserirItem(item);

                codigocadastrado = item.cod_item;
            }

            jsonResult = Json(new
            {
                codigo = codigocadastrado
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}