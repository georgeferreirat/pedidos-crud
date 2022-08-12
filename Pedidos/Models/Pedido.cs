using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public DateTime DtPedido { get; set; }
        public int ProdutoIdProduto { get; set; }
        public Produto? Produto { get; set; }
        public int QtdeProdutos { get; set; }
        public int FornecedorIdFornecedor { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public double ValorTotal { get; set; }
    }
}
