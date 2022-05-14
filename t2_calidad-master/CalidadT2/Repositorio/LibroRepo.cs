using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepo
    {
        Libro LibroDetalle(int id);
        void SaveComentario(Comentario comentario, Usuario user);
    }
    public class LibroRepo : ILibroRepo
    {
        private readonly IAppBibliotecaContext app;
        
        public LibroRepo(IAppBibliotecaContext app)
        {
            this.app = app;
        }

        public Libro LibroDetalle(int id)
        {
            return app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public void SaveComentario(Comentario comentario, Usuario user)
        {
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();
        }
    }
}
