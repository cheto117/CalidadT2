using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IAuthRepo
    {
        Usuario GetUsuario(string username, string password);
        public Usuario Buscar(string username);
    }
    public class AuthRepo : IAuthRepo
    {
        private readonly IAppBibliotecaContext app;

        public AuthRepo(IAppBibliotecaContext app)
        {
            this.app = app;
        }

        public Usuario GetUsuario(string username, string password)
        {
            return app.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }
        public Usuario Buscar(string username)
        {
            var usuario = app.Usuarios.Where(o => o.Username == username).FirstOrDefault();
            return usuario;
        }
    }
}
