using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class OrcamentoController : Controller
    {
        private IOrcamentoRepository repository;
        private IClienteRepository clienteRepository;
        private IProdutoOrcamentoRepository produtoorcamentoRepository;

        public OrcamentoController(IOrcamentoRepository repository, IClienteRepository clienteRepository, IProdutoOrcamentoRepository produtoorcamentoRepository)
        {
            this.repository = repository;
            this.clienteRepository = clienteRepository;
            this.produtoorcamentoRepository = produtoorcamentoRepository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Clientes = clienteRepository.Read();
            List<Orcamento> orcamentos = repository.Read();
            return View(orcamentos);
        }

        public ActionResult Filter(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Clientes = clienteRepository.Read();
            List<Orcamento> orcamentos = repository.ReadByCliente(id);
            return View("Index", orcamentos);
        }

        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Produtos = produtoorcamentoRepository.ReadByOrcamento(id);
            ViewBag.Clientes = clienteRepository.Read();
            var venda = repository.Read(id);
            return View(venda);
        }

        [HttpGet]
        public ActionResult Create()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Clientes = clienteRepository.Read();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Orcamento orcamento)
        {
            repository.Create(orcamento);
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
            ViewBag.Clientes = clienteRepository.Read();
            var orcamento = repository.Read(id);
            return View(orcamento);
        }

        [HttpPost]
        public ActionResult Update(int id, Orcamento orcamento)
        {
            repository.Update(id, orcamento);
            return RedirectToAction("Index");
        } 
    }
}