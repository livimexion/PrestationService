using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Client
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IdClient { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nom")]
        [StringLength(100)]
        public string nom { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Prenom")]
        [StringLength(100)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "*"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? naissance { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Adresse")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string adresse { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"), Display(Name = "Email")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.EmailAddress)]
        public string mail { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Telephone")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.PhoneNumber)]
        public string tel { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Numero d'identite")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string identification { get; set; }

        public String nomComplet
        {
            get
            {
                return nom + "," + prenom;
            }
        }
    }
}