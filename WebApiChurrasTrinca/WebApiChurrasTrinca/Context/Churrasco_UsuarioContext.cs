using Microsoft.EntityFrameworkCore;
using WebApiChurrasTrinca.Models;

namespace WebApiChurrasTrinca.Context
{
    public class Churrasco_UsuarioContext : DbContext
    {
        public Churrasco_UsuarioContext(DbContextOptions<Churrasco_UsuarioContext> options)
           : base(options)
        {
        }

        public DbSet<Churrasco_Usuario> Churas_Usuarios { get; set; }
    }
}
