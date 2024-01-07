using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irimia_web.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Investigație")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Titlu { get; set; }
        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Preț")]
        public decimal Pret { get; set; }
        public int? OrarID { get; set; }
        public Orar? Orar { get; set; }
        [Display(Name = "Specialitate")]
        public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; set; }
    }
}
