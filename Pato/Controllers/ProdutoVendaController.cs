using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class ProdutoVendaController : Controller
    {
        private IProdutoVendaRepository repository;
        private IVendaRepository vendaRepository;
        private IProdutoRepository produtoRepository;


        public ProdutoVendaController(IProdutoVendaRepository repository, IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            this.repository = repository;
            this.vendaRepository = vendaRepository;
            this.produtoRepository = produtoRepository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Vendas = vendaRepository.Read();
            ViewBag.Produtos = produtoRepository.Read();
            List<ProdutoVenda> produtoVendas = repository.Read();
            return View(produtoVendas);
        }

        public ActionResult Filter(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Vendas = vendaRepository.Read();
            ViewBag.Produtos = produtoRepository.Read();
            List<ProdutoVenda> produtoVendas = repository.ReadByVenda(id);
            return View("Index", produtoVendas);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Produtos = produtoRepository.Read();
            ViewBag.Vendas = vendaRepository.Read();
            ViewBag.IdVenda = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoVenda produtoVenda)
        {
            repository.Create(produtoVenda);
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
            return RedirectToAction("Index", "ProdutoVenda");
        } 

        [HttpGet]
        public ActionResult Update(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Produtos = produtoRepository.Read();
            ViewBag.Vendas = vendaRepository.Read();
            var produtoVenda = repository.Read(id);
            return View(produtoVenda);
        }

        [HttpPost]
        public ActionResult Update(int id, ProdutoVenda produtoVenda)
        {
            repository.Update(id, produtoVenda);
            return RedirectToAction("Index");
        } 
    }
}