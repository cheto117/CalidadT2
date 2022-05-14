using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2.Test
{
    [TestFixture]
    public class LibroTest
    {
        [Test]
        public void CasoDetails()
        {
            var repo = new Mock<ILibroRepo>();
            repo.Setup(o => o.LibroDetalle(1)).Returns(new Libro() { Id = 1});

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario());

            var controller = new LibroController(repo.Object,claim.Object);
            var view = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", view.ViewName);
        }
        [Test]
        public void CasoAddComentario()
        {
            var repo = new Mock<ILibroRepo>();
            repo.Setup(o => o.SaveComentario(new Comentario(), new Usuario() { Id = 1}));

            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1});

            var controller = new LibroController(repo.Object, claim.Object);
            var view = controller.AddComentario(new Comentario()) as RedirectToActionResult; ;

            Assert.AreEqual("Details", view.ActionName);
        }
    }
}
