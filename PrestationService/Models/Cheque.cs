using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Cheque 
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idCheque { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Numero cheque")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string numeroChk { get; set; }

       
    }
}