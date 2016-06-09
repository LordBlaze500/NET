using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Leaflet
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Tytuł ulotki")]
        [StringLength(100, ErrorMessage = "Nie może być więcej niż 100 znaków")]
        public string LeafletTitle { get; set; }

        [Display(Name = "Jaki towar reklamuje?")]
        [StringLength(50, ErrorMessage = "Nie może być więcej niż 50 znaków")]
        public string ProductName { get; set; }

        [Display(Name = "Treść ulotki")]
        public string Content { get; set; }

        [Display(Name = "Kolor ulotki")]
        public string Colour { get; set; }

        [Display(Name = "Szerokość [cm]")]
        public int Width { get; set; }

        [Display(Name = "Wysokość [cm]")]
        public int Height { get; set; }
    }
}