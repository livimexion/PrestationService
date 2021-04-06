using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Facture
    {

        public Facture()
        {
            this.Prestations = new HashSet<Prestation>();

        }

        [Key]
        [ScaffoldColumn(false)]
        public int idFacture { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Numero")]
        public int numero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateFacture { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Montant HT")]
        public int montantHT { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Montant TTC")]
        public int montantTTC { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Etat")]
        public Boolean etat { get; set; }

        [Display(Name = "Paiement")]
        public int idPay { get; set; }
        [ForeignKey("idPay")]
        public virtual Paiement Paiement { get; set; }

       public virtual ICollection<Prestation> Prestations { get; set; }

    }
}