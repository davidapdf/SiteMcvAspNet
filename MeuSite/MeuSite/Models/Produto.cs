using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuSite.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProduto  { get; set; }
    }
}