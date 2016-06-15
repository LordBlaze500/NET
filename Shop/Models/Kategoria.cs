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

        [Display(Name = "Nazwa kategorii")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500, ErrorMessage = "Maksymalnie 500 znaków")]
        public string Description{ get; set; }
    }
}