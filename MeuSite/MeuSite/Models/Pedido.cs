using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuSite.Models
{
    public class Pedido
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}