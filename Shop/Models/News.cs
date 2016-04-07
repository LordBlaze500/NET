using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class News
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Tytuł newsa")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        public string NewsTitle { get; set; }

        [Display(Name = "Treść")]
        [StringLength(1000, ErrorMessage = "Maksymalnie 1000 znaków")]
        public string NewsContent{ get; set; }

        [Display(Name = "Data dodania")]
        [DataType(DataType.Date)]
        public DateTime NewsDate{ get; set; }

        [Display(Name = "Autor")]
        [StringLength(30, ErrorMessage = "Maksymalnie 30 znaków")]
        public string NewsAuthor { get; set; }
    }
}