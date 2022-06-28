using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            var usuario = repository.Read(model.Login, model.Senha);

            try{
                if(model.Login == usuario.Login && model.Senha == usuario.Senha)
                {
                    HttpContext.Session.SetInt32("id", usuario.IdPessoa);
                    HttpContext.Session.SetString("nome", usuario.Nome);
                    return RedirectToAction("Home", "Usuario");
                }
                else
                {
                    return RedirectToAction("Login", "Usuario");     
                }            
            }
            catch(Exception ex){
                ViewBag.Message = "Login ou Senha incorretos!!";
                return View();
            }
            finally
            {
                Dispose();
            }
        }

        public ActionResult Index()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            List<Usuario> usuarios = repository.Read();
            return View(usuarios);
        }
        public ActionResult Detalhe(int id)
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var usuario = repository.Read(id);
            return View(usuario);
        }
        public ActionResult Home()
        {
            int? idL = HttpContext.Session.GetInt32("id") as int?;
            if(idL == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            
            repository.Create(usuario);
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
            var usuario = repository.Read(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Update(int id, Usuario usuario)
        {
            repository.Update(id, usuario);
            return RedirectToAction("Index");
        } 
    }
}