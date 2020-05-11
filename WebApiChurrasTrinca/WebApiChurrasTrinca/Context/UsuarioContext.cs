using Microsoft.EntityFrameworkCore;
using WebApiChurrasTrinca.Models;

namespace WebApiChurrasTrinca.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
           : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
