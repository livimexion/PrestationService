using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Carte 
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idCarte { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Type de Carte")]
        [StringLength(100)]
        public string type { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Numero carte")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string numero { get; set; }

      
    }
}