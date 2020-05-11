using Microsoft.EntityFrameworkCore;
using WebApiChurrasTrinca.Models;

namespace WebApiChurrasTrinca.Context
{
    public class ChurrascoContext : DbContext
    {
        public ChurrascoContext(DbContextOptions<ChurrascoContext> options)
           : base(options)
        {
        }

        public DbSet<Churrasco> Churrascos { get; set; }
    }
}
