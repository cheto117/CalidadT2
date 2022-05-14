using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalidadT2.Test
{
    [TestFixture]
    public class HomeTest
    {
        [Test]
        public void CasoIndex()
        {
            var repo = new Mock<IHomeRepo>();
            repo.Setup(o => o.GetLibros()).Returns(new List<Libro>());

            var controller = new HomeController(repo.Object);
            var view = controller.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
