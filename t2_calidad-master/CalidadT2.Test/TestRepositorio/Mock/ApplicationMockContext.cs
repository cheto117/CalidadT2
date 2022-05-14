using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadT2.Test.TestRepositorio.Mock
{
    class ApplicationMockContext
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            IQueryable<Usuario> userData = GetUserData();

            var mockDbSetUser = new Mock<DbSet<Usuario>>();
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockDbSetUser.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            mockDbSetUser.Setup(m => m.AsQueryable()).Returns(userData);

            IQueryable<Autor> autorData = GetAutorData();

            var mockDbSetAutor = new Mock<DbSet<Autor>>();
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.Provider).Returns(autorData.Provider);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.Expression).Returns(autorData.Expression);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.ElementType).Returns(autorData.ElementType);
            mockDbSetAutor.As<IQueryable<Autor>>().Setup(m => m.GetEnumerator()).Returns(autorData.GetEnumerator());
            mockDbSetAutor.Setup(m => m.AsQueryable()).Returns(autorData);

            IQueryable<Comentario> comentarioData = GetComentarioData();
            var mockDbSetComentario = new Mock<DbSet<Comentario>>();
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.Provider).Returns(comentarioData.Provider);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.Expression).Returns(comentarioData.Expression);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.ElementType).Returns(comentarioData.ElementType);
            mockDbSetComentario.As<IQueryable<Comentario>>().Setup(m => m.GetEnumerator()).Returns(comentarioData.GetEnumerator());
            mockDbSetComentario.Setup(m => m.AsQueryable()).Returns(comentarioData);

            IQueryable<Libro> libroData = GetLibroData();

            var mockDbSetLibro = new Mock<DbSet<Libro>>();
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Provider).Returns(libroData.Provider);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Expression).Returns(libroData.Expression);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.ElementType).Returns(libroData.ElementType);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.GetEnumerator()).Returns(libroData.GetEnumerator());
            mockDbSetLibro.Setup(m => m.AsQueryable()).Returns(libroData);

            IQueryable<Biblioteca> bibliotecaData = GetBibliotecaData();

            var mockDbSetBilbioteca = new Mock<DbSet<Biblioteca>>();
            mockDbSetBilbioteca.As<IQueryable<Biblioteca>>().Setup(m => m.Provider).Returns(bibliotecaData.Provider);
            mockDbSetBilbioteca.As<IQueryable<Biblioteca>>().Setup(m => m.Expression).Returns(bibliotecaData.Expression);
            mockDbSetBilbioteca.As<IQueryable<Biblioteca>>().Setup(m => m.ElementType).Returns(bibliotecaData.ElementType);
            mockDbSetBilbioteca.As<IQueryable<Biblioteca>>().Setup(m => m.GetEnumerator()).Returns(bibliotecaData.GetEnumerator());
            mockDbSetBilbioteca.Setup(m => m.AsQueryable()).Returns(bibliotecaData);
            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSetUser.Object);
            mockContext.Setup(c => c.Autores).Returns(mockDbSetAutor.Object);
            mockContext.Setup(c => c.Comentarios).Returns(mockDbSetComentario.Object);
            mockContext.Setup(c => c.Libros).Returns(mockDbSetLibro.Object);
            mockContext.Setup(c => c.Bibliotecas).Returns(mockDbSetBilbioteca.Object);
            return mockContext;
        }
        private static IQueryable<Usuario> GetUserData()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "1234", Nombres = "Admin" },
                new Usuario { Id = 2, Username = "user1", Password = "1234", Nombres = "User1" },
                new Usuario { Id = 3, Username = "user2", Password = "1234", Nombres = "User2" },
                new Usuario { Id = 4, Username = "user3", Password = "1234", Nombres = "User3" },
                new Usuario { Id = 5, Username = "user4", Password = "1234", Nombres = "User4" },
            }.AsQueryable();
        }

        private static IQueryable<Autor> GetAutorData()
        {
            return new List<Autor>
            {
                new Autor { Id = 1, Nombres = "Autor1" },
                new Autor { Id = 2, Nombres = "Autor2" },
                new Autor { Id = 3, Nombres = "Autor3" },
                new Autor { Id = 4, Nombres = "Autor4" },
                new Autor { Id = 5, Nombres = "Autor5" },
                new Autor { Id = 6, Nombres = "Autor6" },
            }.AsQueryable();
        }

        private static IQueryable<Comentario> GetComentarioData()
        {
            return new List<Comentario>
            {
                new Comentario {
                    Id = 1,
                    LibroId = 1,
                    UsuarioId = 1,
                    Texto = "Comentario1",
                    Fecha = new DateTime(2021, 08,20, 10, 10, 0),
                    Puntaje = 0,
                    Usuario = GetUserData().Where(o => o.Id == 1).First(),
                },
                new Comentario {
                    Id = 2,
                    LibroId = 2,
                    UsuarioId = 2,
                    Texto = "Comentario2",
                    Fecha = new DateTime(2021, 08,21, 10, 10, 0),
                    Puntaje = 0,
                    Usuario = GetUserData().Where(o => o.Id == 1).First(),
                },
                new Comentario {
                    Id = 3,
                    LibroId = 3,
                    UsuarioId = 3,
                    Texto = "Comentario2",
                    Fecha = new DateTime(2021, 08,21, 10, 10, 0),
                    Puntaje = 0,
                    Usuario = GetUserData().Where(o => o.Id == 1).First(),
                },
            }.AsQueryable();
        }

        private static IQueryable<Libro> GetLibroData()
        {
            return new List<Libro>
            {
                new Libro { 
                    Id = 1,
                    Nombre = "Libro1", 
                    Imagen = "Imagen1",
                    AutorId = 1,
                    Autor = GetAutorData().Where(x => x.Id == 1).First(),
                    Puntaje = 0,
                    Comentarios = GetComentarioData().Where(x => x.LibroId == 1).ToList()
                },
                new Libro {
                    Id = 2,
                    Nombre = "Libro2",
                    Imagen = "Imagen1",
                    AutorId = 2,
                    Autor = GetAutorData().Where(x => x.Id == 2).First(),
                    Puntaje = 0,
                    Comentarios = GetComentarioData().Where(x => x.LibroId == 2).ToList()
                },
            }.AsQueryable();
        }

        private static IQueryable<Biblioteca> GetBibliotecaData()
        {
            return new List<Biblioteca>
            {
                new Biblioteca {
                    Id = 1,
                    UsuarioId = 1,
                    LibroId = 1 ,
                    Usuario = GetUserData().Where(o => o.Id == 1).First(),
                    Libro = GetLibroData().Where(o => o.Id == 1).First(),
                },
                new Biblioteca {
                    Id = 1,
                    UsuarioId = 2,
                    LibroId = 2 ,
                    Usuario = GetUserData().Where(o => o.Id == 2).First(),
                    Libro = GetLibroData().Where(o => o.Id == 1).First(),
                },
                new Biblioteca {
                    Id = 1,
                    UsuarioId = 2,
                    LibroId = 2 ,
                    Usuario = GetUserData().Where(o => o.Id == 2).First(),
                    Libro = GetLibroData().Where(o => o.Id == 2).First(),
                },

            }.AsQueryable();
        }
    }
}
