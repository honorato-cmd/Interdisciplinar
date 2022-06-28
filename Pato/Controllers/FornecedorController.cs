using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class FornecedorController : Controller
    {
        private IFornecedorRepository repository;

        public FornecedorController(IFornecedorRepository repository)
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
            List<Fornecedor> fornecedores = repository.Read();
            return View(fornecedores);
        }
        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var fornecedor = repository.Read(id);
            return View(fornecedor);
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
        public ActionResult Create(Fornecedor fornecedor)
        {
            repository.Create(fornecedor);
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
            var fornecedor = repository.Read(id);
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Update(int id, Fornecedor fornecedor)
        {
            repository.Update(id, fornecedor);
            return RedirectToAction("Index");
        } 
    }
}