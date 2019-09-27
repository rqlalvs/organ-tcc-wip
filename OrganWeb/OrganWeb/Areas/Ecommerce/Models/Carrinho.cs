﻿using OrganWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Ecommerce.Models
{
    public class Carrinho
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Anuncio")]
        public int IdAnuncio { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        public int Quantidade { get; set; }
        public bool Status { get; set; }

        public virtual Anuncio Anuncio { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}