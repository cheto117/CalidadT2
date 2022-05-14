using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2.Test.TestRepositorio.Mock;
using Moq;
using NUnit.Framework;

namespace CalidadT2.Test.TestRepositorio
{
    class AuthRepoTest
    {
        private Mock<AppBibliotecaContext> mockContext;

        [SetUp]
        public void SetUp()
        {
            mockContext = ApplicationMockContext.GetApplicationContextMock();
        }

        [Test]
        public void TestBuscarCaso01()
        {
            var respository = new AuthRepo(mockContext.Object);
            var usuario = respository.Buscar("admin");

            Assert.IsNotNull(usuario);
        }

        [Test]
        public void TestBuscarCaso02()
        {
            var respository = new AuthRepo(mockContext.Object);
            var usuario = respository.Buscar("user5");

            Assert.IsNull(usuario);
        }
    }
}
