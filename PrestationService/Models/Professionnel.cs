using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Professionnel
    {
        public Professionnel()
        {
            this.services = new HashSet<Service>();

        }

        [Key]
        [ScaffoldColumn(false)]
        public int IdProfessionnel { get; set; }

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

        [Required(ErrorMessage = "*"), Display(Name = "Diplome")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string diplome { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Specialite")]
        [MaxLength(50, ErrorMessage = "taille maximale 50")]
        public string specialite { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Ninea")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string ninea { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Registre de commerce")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string registre { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Statut")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string statut { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Experience")]
        public string experience { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Photo")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Choisir une image")]
        public string photo { get; set; }

        public virtual ICollection<Service> services { get; set; }

        public String nomComplet
        {
            get
            {
                return nom + " " + prenom;
            }
        }
    }
}