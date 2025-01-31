using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPMVC.Models.ViewModels
{
    public class TacheDelete
    {
        [DisplayName("Titre : ")]
        public string Titre { get; set; }
    }
}
