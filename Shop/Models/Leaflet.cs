using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Products")]
        [Display(Name = "Id produktu")]
        public virtual long ProductsId { get; set; }
        public virtual Products Products { get; set; }

        [Display(Name = "Treść ulotki")]
        public string Content { get; set; }

        [Display(Name = "Kolor ulotki")]
        public string Colour { get; set; }

        [Display(Name = "Szerokość [cm]")]
        [Range(1, 50, ErrorMessage = "Podaj wartość z zakresu 1-50")]
        public int Width { get; set; }

        [Display(Name = "Wysokość [cm]")]
        [Range(1, 50, ErrorMessage = "Podaj wartość z zakresu 1-50")]
        public int Height { get; set; }
    }
}