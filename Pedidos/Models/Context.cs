using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Pedidos.Models
{
    public class Context : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
