using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Complaint
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Kod produktu")]
        [StringLength(45, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string ProductCode { get; set; }
        [Display(Name = "Data sprzedarzy")]
        public DateTime SaleDate { get; set; }
        [Display(Name = "Nr faktury")]
        [StringLength(45, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string Invoice { get; set; }
        [Display(Name = "Nazwa produktu")]
        [StringLength(50, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string ProductName { get; set; }
        [Display(Name = "Opis uszkodzenia")]
        [StringLength(250, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string DamageDesc { get; set; }
    }
}