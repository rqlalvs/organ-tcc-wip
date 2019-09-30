﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrganWeb.Models;
using OrganWeb.Models.Banco;

namespace OrganWeb.Areas.Sistema.Models.Administrativo
{
    [Table("tbSolo")]
    public class Solo : Repository<Solo>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Tipo de Solo")]
        public int Tipo { get; set; }
       
        [Range(0.01, 999.99)]
        [Display(Name = "Incidência Solar")]
        public double IncSolar { get; set; }
        
        [Range(0.01, 999.99)]
        [Display(Name = "Incidência do Vento")]
        public double IncVento { get; set; }
        
        [Range(0.01, 999.99)]
        public double Acidez { get; set; }
    }
}