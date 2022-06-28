using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository repository;
        private IFornecedorRepository fornecedorRepository;

        public ProdutoController(IProdutoRepository repository, IFornecedorRepository fornecedorRepository)
        {
            this.repository = repository;
            this.fornecedorRepository = fornecedorRepository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Fornecedores = fornecedorRepository.Read();
            List<Produto> produtos = repository.Read();
            return View(produtos);
        }
        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var produto = repository.Read(id);
            return View(produto);
        }

        public ActionResult Filter(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Fornecedores = fornecedorRepository.Read();
            List<Produto> produtos = repository.ReadByFornecedor(id);
            return View("Index", produtos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Fornecedores = fornecedorRepository.Read();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            repository.Create(produto);
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
            ViewBag.Fornecedores = fornecedorRepository.Read();
            var produto = repository.Read(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Update(int id, Produto produto)
        {
            repository.Update(id, produto);
            return RedirectToAction("Index");
        } 
    }
}