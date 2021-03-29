using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestationService.Models
{
    public class Personne
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idPerson { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nom")]
        [StringLength(100)]
        public string nom { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Prenom")]
        [StringLength(100)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "*"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? naissance { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Adresse")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string adresse { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"), Display(Name = "Email")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.EmailAddress)]
        public string mail { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Nouveau mot de passe")]
        [StringLength(100, ErrorMessage = "Le {0} doit compter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Telephone")]
        [MaxLength(80, ErrorMessage = "taille maximale 80"), DataType(DataType.PhoneNumber)]
        public string tel { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Numero d'identite")]
        [MaxLength(30, ErrorMessage = "taille maximale 30")]
        public string identification { get; set; }

        [Display(Name = "Role")]
        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public virtual Role Role { get; set; }

        [MaxLength(100)]
        public string Id { get; set; } 

        //public ICollection<Client> clients { get; set; }
        //public ICollection<Professionnel> professionnels { get; set; }
    }


}