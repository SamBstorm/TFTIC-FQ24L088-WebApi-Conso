using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoApi.Models
{
    internal class Tache
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateCreation { get; set; }
        public string Status { get; set; }
    }
}
