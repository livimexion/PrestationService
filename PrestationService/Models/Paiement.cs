using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Paiement
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idPay { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Type de paiement")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string typPay { get; set; }

        [Display(Name = "Cheque")]
        public int IdCheque { get; set; }
        [ForeignKey("IdCheque")]
        public virtual Cheque Cheque { get; set; }

        [Display(Name = "Carte")]
        public int idCarte { get; set; }
        [ForeignKey("idCarte")]
        public virtual Carte Carte { get; set; }

        [Display(Name = "Transfert")]
        public int idCash { get; set; }
        [ForeignKey("idCash")]
        public virtual Transfert Transfert { get; set; }
    }
}