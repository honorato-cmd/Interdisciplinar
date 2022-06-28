using Pato.Models;
using Microsoft.AspNetCore.Mvc;
using Pato.Repositories;

namespace Pato.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login","Usuario");
        }

        public ActionResult Teste()
        {
            try{
                int? id = HttpContext.Session.GetInt32("id") as int?;
                if(id == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }
                return View();
            }
            catch(Exception ex) 
            {
                return RedirectToAction("Index", "Home");
            }
            finally
            {
                Dispose();
            }
        }
    }
}