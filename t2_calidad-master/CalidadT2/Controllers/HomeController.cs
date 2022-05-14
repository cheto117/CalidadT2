using Microsoft.AspNetCore.Mvc;
using CalidadT2.Repositorio;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepo app;
        public HomeController(IHomeRepo app)
        {
            this.app = app;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            var model = app.GetLibros();
            return View("Index",model);
        }
    }
}
