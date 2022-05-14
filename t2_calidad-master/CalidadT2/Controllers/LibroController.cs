using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepo app;
        private readonly IClaimService claim;

        public LibroController(ILibroRepo app, IClaimService claim)
        {
            this.app = app;
            this.claim = claim;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = app.LibroDetalle(id);
            return View("Details", model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            claim.SetHttpContext(HttpContext);
            Usuario user = claim.GetLoggedUser();

            app.SaveComentario(comentario, user);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }
    }
}
