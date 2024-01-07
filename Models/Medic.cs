using System.ComponentModel.DataAnnotations;

namespace Irimia_web.Models
{
    public class Medic
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Display(Name = "Nume")]
        public string FullName
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
