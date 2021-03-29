using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Transfert
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idCash { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = " Operateur")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string operateur { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Telephone")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.PhoneNumber)]
        public string tel { get; set; }

      
    }
}