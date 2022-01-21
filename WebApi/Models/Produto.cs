using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }    
        public decimal Valor { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
