using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPMVC.Models.ViewModels
{
    public class TacheEditForm
    {
        [DisplayName("Titre : ")]
        [Required(ErrorMessage = "Le champ 'Titre' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs 'Titre' doit contenir un minimum de 2 caractères.")]
        [MaxLength(50, ErrorMessage = "Le champs 'Titre' doit contenir un maximum de 50 caractères.")]
        public string Titre { get; set; }
        [DisplayName("Status : ")]
        [Required(ErrorMessage = "Le champ 'Status' est obligatoire.")]
        public string Status { get; set; }
    }
}
