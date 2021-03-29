using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Prestation
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idPrestation { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Adresse")]
        [StringLength(100)]
        public string adresse { get; set; }


        [Display(Name = "Client")]
        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }


        [Display(Name = "Service")]
        public int idService { get; set; }
        [ForeignKey("idService")]
        public virtual Service Service { get; set; }

        [Display(Name = "Facture")]
        public int IdFacture { get; set; }
        [ForeignKey("IdFacture")]
        public virtual Facture Facture { get; set; }
    }
}