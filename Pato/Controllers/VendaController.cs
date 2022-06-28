using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class VendaController : Controller
    {
        private IVendaRepository repository;
        private IClienteRepository clienteRepository;
        private IProdutoVendaRepository produtovendaRepository;

        public VendaController(IVendaRepository repository, IClienteRepository clienteRepository, IProdutoVendaRepository produtovendaRepository)
        {
            this.repository = repository;
            this.clienteRepository = clienteRepository;
            this.produtovendaRepository = produtovendaRepository;
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Clientes = clienteRepository.Read();
            List<Venda> vendas = repository.Read();
            return View(vendas);
        }

        public ActionResult Filter(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Clientes = clienteRepository.Read();
            List<Venda> vendas = repository.Read();
            return View("Index", vendas);
        }
        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Produtos = produtovendaRepository.ReadByVenda(id);
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
        public ActionResult Create(Venda venda)
        {
            repository.Create(venda);
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
            ViewBag.Produtos = produtovendaRepository.ReadByVenda(id);
            ViewBag.Clientes = clienteRepository.Read();
            var venda = repository.Read(id);
            return View(venda);
        }

        [HttpPost]
        public ActionResult Update(int id, Venda venda)
        {
            repository.Update(id, venda);
            return RedirectToAction("Index");
        } 
    }
}