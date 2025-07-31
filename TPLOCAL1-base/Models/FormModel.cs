using System;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        // --- Section: Informations personnelles ---

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Sexe { get; set; }

        public string Adresse { get; set; }

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres.")]
        public string CodePostal { get; set; }

        public string Ville { get; set; }

        [EmailAddress(ErrorMessage = "Le format de l'adresse email est incorrect.")]
        public string Email { get; set; }

        // --- Section: Informations de formation suivie ---

        [DataType(DataType.Date)]
        public DateTime DateDebutFormation { get; set; }

        public string TypeFormation { get; set; }

        // --- Section: Avis sur la formation ---

        public string AvisCobol { get; set; }

        public string AvisCSharp { get; set; }
    }
}