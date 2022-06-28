using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class ProdutoOrcamentoController : Controller
    {
        private IProdutoOrcamentoRepository repository;
        private IOrcamentoRepository orcamentoRepository;
        private IProdutoRepository produtoRepository;


        public ProdutoOrcamentoController(IProdutoOrcamentoRepository repository, IOrcamentoRepository orcamentoRepository, IProdutoRepository produtoRepository)
        {
            this.repository = repository;
            this.orcamentoRepository = orcamentoRepository;
            this.produtoRepository = produtoRepository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Orcamentos = orcamentoRepository.Read();
            ViewBag.Produtos = produtoRepository.Read();
            List<ProdutoOrcamento> produtoOrcamentos = repository.Read();
            return View(produtoOrcamentos);
        }

        public ActionResult Filter(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Produtos = produtoRepository.Read();
            ViewBag.Orcamentos = orcamentoRepository.Read();
            List<ProdutoOrcamento> produtoOrcamentos = repository.ReadByOrcamento(id);
            return View("Index", produtoOrcamentos);
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
            ViewBag.Orcamentos = orcamentoRepository.Read();
            ViewBag.IdOrcamento = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoOrcamento produtoOrcamento)
        {
            repository.Create(produtoOrcamento);
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
            ViewBag.Produtos = produtoRepository.Read();
            ViewBag.Orcamentos = orcamentoRepository.Read();
            var produtoOrcamento = repository.Read(id);
            return View(produtoOrcamento);
        }

        [HttpPost]
        public ActionResult Update(int id, ProdutoOrcamento produtoOrcamento)
        {
            repository.Update(id, produtoOrcamento);
            return RedirectToAction("Index");
        } 
    }
}