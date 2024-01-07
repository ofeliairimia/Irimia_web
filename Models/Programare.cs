using System.ComponentModel.DataAnnotations;

namespace Irimia_web.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [Display(Name = "Nume Pacient")]
        public int? PacientID { get; set; }
        public Pacient? Pacient { get; set; }
        [Display(Name = "Denumire Investigație")]
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Data programării")]
        public DateTime DataProgramare { get; set; }
    }
}
