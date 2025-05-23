using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GranShopAPI.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome da categoria!")]
        [StringLength(30, ErrorMessage = "O tamanho máximo permitido para o nome da categoria é de 30 caracteres!")]
        public string Nome { get; set; }
    }
}