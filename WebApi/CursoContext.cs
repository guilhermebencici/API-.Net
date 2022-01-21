using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class CursoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conection = "server=localhost;database=curso2022;user id=gama;password=gama123";
            optionsBuilder.UseMySql(conection, ServerVersion.AutoDetect(conection));
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
