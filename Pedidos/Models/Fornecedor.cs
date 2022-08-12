using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
        public string EmailContato { get; set; }
        public string NomeContato { get; set; }
    }
}
