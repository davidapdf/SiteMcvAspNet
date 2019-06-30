using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuSite.Models
{
    public class PedidoProduto
    {
        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto{ get; set; }
    }
}