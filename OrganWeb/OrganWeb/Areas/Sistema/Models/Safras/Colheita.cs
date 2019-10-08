﻿using OrganWeb.Areas.Sistema.Models.Armazenamento;
using OrganWeb.Models.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganWeb.Areas.Sistema.Models.Safras
{
    [Table("tbColheita")]
    public class Colheita : Repository<Colheita>
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        
        [Display(Name = "Quantidade de perdas")]
        public double QtdPerdas { get; set; }

        [Display(Name = "Quantidade total")]
        public double QtdTotal { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Plantio")]
        public int IdPlantio { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Produto")]
        public int IdProd { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Plantio Plantio { get; set; }
    }
}