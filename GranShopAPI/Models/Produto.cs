using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do produto!")]
        [StringLength(50, ErrorMessage = "O tamanho máximo permitido para o nome do produto é de 50 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira a descrição do produto!")]
        [StringLength(160, ErrorMessage = "O tamanho máximo permitido para a descrição do produto é de 160 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Insira a quantidade do produto em estoque!")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "Insira o valor de compra do produto!")]
        public decimal ValorCusto { get; set; }

        [Required(ErrorMessage = "Insira o valor de venda do produto!")]
        public decimal ValorVenda { get; set; }

        public bool Destaque { get; set; }

        [Required(ErrorMessage = "Insira a categoria do produto!")]
        public int CategoriaId { get; set; }
        
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}