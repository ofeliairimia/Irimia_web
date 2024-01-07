﻿using System.ComponentModel.DataAnnotations;

namespace Irimia_web.Models
{
    public class Specialitate
    {
        public int ID { get; set; }
        [Display(Name = "Specialitate")]
        public string NumeSpecialitate { get; set; }
        public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; set; }

    }
}
