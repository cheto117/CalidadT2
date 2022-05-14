using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IHomeRepo
    {
        List<Libro> GetLibros();
    }
    public class HomeRepo : IHomeRepo
    {
        private readonly IAppBibliotecaContext app;

        public HomeRepo(IAppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Libro> GetLibros()
        {
            return app.Libros.Include(o => o.Autor).ToList();
        }
    }
}
