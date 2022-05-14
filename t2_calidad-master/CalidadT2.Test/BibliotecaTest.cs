using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadT2.Test
{
    [TestFixture]
    public class BibliotecaTest
    {
        [Test]
        public void CasoIndex()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1});

            var repo = new Mock<IBibliotecaRepo>();
            repo.Setup(o => o.GetBibliotecas(1)).Returns(new List<Biblioteca>());

            var controller = new BibliotecaController(repo.Object, claim.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
        [Test]
        public void CasoAdd()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var repo = new Mock<IBibliotecaRepo>();
            repo.Setup(o => o.AddBiblioteca(1,1));

            var controller = new BibliotecaController(repo.Object, claim.Object);
            var view = controller.Add(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
        [Test]
        public void CasoMarcarComoLeyendo()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var repo = new Mock<IBibliotecaRepo>();
            repo.Setup(o => o.Biblioteca(1, new Usuario() { Id = 1})).Returns(new Biblioteca() { Id = 1 });
            repo.Setup(o => o.Leyendo(new Biblioteca()));

            var controller = new BibliotecaController(repo.Object, claim.Object);
            var view = controller.MarcarComoLeyendo(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
        [Test]
        public void CasoMarcarComoTerminado()
        {
            var claim = new Mock<IClaimService>();
            claim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var repo = new Mock<IBibliotecaRepo>();
            repo.Setup(o => o.Biblioteca(1, new Usuario() { Id = 1 })).Returns(new Biblioteca() { Id = 1 });
            repo.Setup(o => o.Terminado(new Biblioteca()));

            var controller = new BibliotecaController(repo.Object, claim.Object);
            var view = controller.MarcarComoTerminado(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
    }
}
