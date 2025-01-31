using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPMVC.Models.ViewModels
{
    public class TacheListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant : ")]
        public int Id { get; set; }
        [DisplayName("Titre : ")]
        public string Titre { get; set; }
    }
}
