using CalidadT2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace CalidadT2.Repositorio
{
    public interface IClaimService
    {
        Usuario GetLoggedUser();
        void SetHttpContext(HttpContext httpContext);
        void Logout();
        void Login(ClaimsPrincipal principal);
    }
    public class ClaimService : IClaimService
    {
        private readonly IAppBibliotecaContext context;
        private HttpContext httpContext;

        public ClaimService(IAppBibliotecaContext context)
        {
            this.context = context;
        }

        public Usuario GetLoggedUser()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            return context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
        }

        public void Login(ClaimsPrincipal principal)
        {
            httpContext.SignInAsync(principal);
        }

        public void Logout()
        {
            httpContext.SignOutAsync();
        }

        public void SetHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;  
        }
    }
}
