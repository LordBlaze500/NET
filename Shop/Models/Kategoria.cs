using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Kategoria
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string Name { get; set; }

    }
}