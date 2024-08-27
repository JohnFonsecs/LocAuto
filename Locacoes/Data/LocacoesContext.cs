using Locacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Locacoes.Data
{
    public class LocacoesContext : DbContext
    {
        public LocacoesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
