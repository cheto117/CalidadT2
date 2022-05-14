using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepo
    {
        List<Biblioteca> GetBibliotecas(int userId);
        Biblioteca Biblioteca(int libroId, Usuario user);
        void AddBiblioteca(int libro, int userID);
        void Leyendo(Biblioteca biblioteca);
        void Terminado(Biblioteca biblioteca);

    }
    public class BibliotecaRepo : IBibliotecaRepo
    {
        private readonly IAppBibliotecaContext app;

        public BibliotecaRepo(IAppBibliotecaContext app)
        {
            this.app = app;
        }

        public void AddBiblioteca(int libro,int userID)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = userID,
                Estado = ESTADO.POR_LEER
            };

            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();
        }

        public Biblioteca Biblioteca(int libroId, Usuario user)
        {
            return app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();
        }

        public List<Biblioteca> GetBibliotecas(int userId)
        {
            return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == userId)
                .ToList();
        }

        public void Leyendo(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.LEYENDO;
            app.SaveChanges();
        }

        public void Terminado(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.TERMINADO;
            app.SaveChanges();
        }
    }
}
