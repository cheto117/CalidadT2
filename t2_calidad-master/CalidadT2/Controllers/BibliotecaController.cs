using System.Linq;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaRepo app;
        private readonly IClaimService claim;

        public BibliotecaController(IBibliotecaRepo app, IClaimService claim)
        {
            this.app = app;
            this.claim = claim;
        }

        [HttpGet]
        public IActionResult Index()
        {
            claim.SetHttpContext(HttpContext);
            Usuario user = claim.GetLoggedUser();

            var model = app.GetBibliotecas(user.Id);

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            claim.SetHttpContext(HttpContext);
            Usuario user = claim.GetLoggedUser();


            app.AddBiblioteca(libro,user.Id);
            //TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            claim.SetHttpContext(HttpContext);
            Usuario user = claim.GetLoggedUser();

            var libro = app.Biblioteca(libroId, user);
            app.Leyendo(libro);
            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            claim.SetHttpContext(HttpContext);
            Usuario user = claim.GetLoggedUser();

            var libro = app.Biblioteca(libroId, user);
            app.Terminado(libro);
            //TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }
    }
}
