using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC.Models.ViewModels
{
    public class TacheDetails
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant : ")]
        public int Id { get; set; }
        [DisplayName("Titre : ")]
        public string Titre { get; set; }
        [DisplayName("Date de création : ")]
        public DateTime DateCreation { get; set; }
        [DisplayName("Status : ")]
        public string Status { get; set; }
    }
}
