using CalidadT2.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Models
{
    public interface IAppBibliotecaContext
    {
        DbSet<Libro> Libros { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Biblioteca> Bibliotecas { get; set; }
        DbSet<Comentario> Comentarios { get; set; }
        DbSet<Autor> Autores { get; set; }
        int SaveChanges();
    }

    public class AppBibliotecaContext: DbContext, IAppBibliotecaContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Autor> Autores { get; set; }

        public AppBibliotecaContext(DbContextOptions<AppBibliotecaContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LibroMap());
            modelBuilder.ApplyConfiguration(new BibliotecaMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
        }
    }
}
