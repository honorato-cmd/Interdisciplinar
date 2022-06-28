using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class PessoaController : Controller
    {
        private IPessoaRepository repository;

        public PessoaController(IPessoaRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            List<Pessoa> pessoas = repository.Read();
            return View(pessoas);
        }
        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var pessoa = repository.Read(id);
            return View(pessoa);
        }

        [HttpGet]
        public ActionResult Create()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            repository.Create(pessoa);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var pessoa = repository.Read(id);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Update(int id, Pessoa pessoa)
        {
            repository.Update(id, pessoa);
            return RedirectToAction("Index");
        } 
    }
}