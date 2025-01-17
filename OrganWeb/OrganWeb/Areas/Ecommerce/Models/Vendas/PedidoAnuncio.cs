﻿using OrganWeb.Areas.Ecommerce.Models.zBanco;
using OrganWeb.Areas.Ecommerce.Models.zRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Ecommerce.Models.Vendas
{
    [Table("tbPedidoAnuncio")]
    public class PedidoAnuncio : EcommerceRepository<PedidoAnuncio>
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Anuncio")]
        public int IdAnuncio { get; set; }

        [Required]
        public int Qtd { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Anuncio Anuncio { get; set; }
    }
}