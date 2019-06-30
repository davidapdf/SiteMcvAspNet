using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MeuSite.Controllers
{
    public class ExemploController : Controller
    {
        // GET: Exemplo
       public string Index()
        {
            return "Hello World";
        }
        
        public string IndexParametro(int id)
        {
            return "Hello World " + id.ToString();
        }

        public string IndexParametroQuery(int id, int? cpf)
        {

            StringBuilder sd = new StringBuilder();
            sd.Append("Hello World ");
            sd.Append(id.ToString());
            sd.Append("CPF: ");
            sd.Append(cpf.ToString());

           // HttpUtility.HtmlEncode($"Hello World {id.ToString()} cpf: {cpf.ToString()}");

            //return sd.ToString();
            return string.Format("Hello World {0} Nome: {1}", id, cpf);
          //  return $"Hello World {id.ToString()} cpf: {cpf.ToString()}";

        }
        [Route("exemplo/minharotacustomizada/{nome}/{idade}")]
        public string IndexRota(string nome, int idade)
        {
            return string.Format("Nova Rota Nome: {0} Idade: {1}" , nome,idade);
        }

        public ActionResult Tela()
        {
            ViewBag.TextoDoTitulo = "Titulo da pagina";
            ViewBag.DataHora = DateTime.Now.ToLongTimeString();
           return View(new List<string> { "Olá ","Oi ","AAA " });
        }

        public JsonResult ExemploJson()
        {
            return Json(new List<string> { "Olá ", "Oi ", "AAA " },JsonRequestBehavior.AllowGet);
        }

    }
}


