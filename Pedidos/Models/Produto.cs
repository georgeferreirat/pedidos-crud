using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
        public double Valor { get; set; }
    }
}
