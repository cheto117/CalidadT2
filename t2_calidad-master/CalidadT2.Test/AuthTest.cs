using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalidadT2.Test
{
    [TestFixture]
    public class AuthTest
    {
        [Test]
        public void CasoLogin()
        {
            var controller = new AuthController(null,null);
            var view = controller.Login() as ViewResult;

            Assert.AreEqual("Login", view.ViewName);
        }
        [Test]
        public void CasoLoginPost()
        {
            var service = new Mock<IClaimService>();
            
            var repository = new Mock<IAuthRepo>();
            repository.Setup(o => o.GetUsuario("Hola","Mundo")).Returns(new Models.Usuario());

            var controller = new AuthController(repository.Object, service.Object);
            var view = controller.Login("Hola","Mundo") as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void CasoLoginPostMal()
        {
            var service = new Mock<IClaimService>();

            var repository = new Mock<IAuthRepo>();
            repository.Setup(o => o.GetUsuario(null, null)).Returns(new Models.Usuario());

            var controller = new AuthController(repository.Object, service.Object);
            var view = controller.Login("Hola", "Mundo") as ViewResult;

            Assert.AreEqual("Login", view.ViewName);
        }

        [Test]
        public void CasoLogOut()
        {
            var service = new Mock<IClaimService>();
            service.Setup(o => o.Logout());

            var repository = new Mock<IAuthRepo>();

            var controller = new AuthController(repository.Object, service.Object);
            var view = controller.Logout() as RedirectToActionResult;

            Assert.AreEqual("Login", view.ActionName);
        }
    }
}
