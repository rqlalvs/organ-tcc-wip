﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrganWeb.Models;
using OrganWeb.Models.Banco;

namespace OrganWeb.Areas.Sistema.Models.Armazenamento
{
    [Table("tbHistEstoque")]
    public class HistoricoEstoque : Repository<HistoricoEstoque>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double QtdAlterada { get; set; }

        [Required]
        [Range(0.01, 99999.99)]
        public double QtdAntiga { get; set; }

        [Required]
        public DateTime DtAlteracao { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Desc { get; set; }
                
        [Required]
        [ForeignKey("Estoque")]
        public int IdEstoque { get; set; }

        public virtual Estoque Estoque { get; set; }
    }
}