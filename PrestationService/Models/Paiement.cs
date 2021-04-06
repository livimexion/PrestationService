using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public enum TypePay
    {
        CARTE, CHEQUE, TRANSFERT
    }

    public class Paiement
    {
        public enum TypePay
        {
            CARTE, CHEQUE, TRANSFERT
        }

        [Key]
        [ScaffoldColumn(false)]
        public int idPay { get; set; }

        
        public TypePay typPay { get; set; }

        [Display(Name = "Type de Carte")]
        [StringLength(100)]
        public string typeCarte { get; set; }

        [Display(Name = "Numero carte")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string numeroCarte { get; set; }

        [Display(Name = "Numero cheque")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string numeroChk { get; set; }

        [Display(Name = " Operateur")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string operateur { get; set; }

        [Display(Name = "Telephone")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.PhoneNumber)]
        public string tel { get; set; }

       
    }
}