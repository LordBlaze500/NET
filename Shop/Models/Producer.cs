using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Producer
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }       

        [DataType(DataType.Text)]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }
        
        [Display(Name = "Adres")]
        [DataType(DataType.Text)]
        public string Adres { get; set; }

        [Display(Name = "Nip")]
        [DataType(DataType.Currency)]
        public string Nip { get; set; }

        [Display(Name = "Regon")]
        [DataType(DataType.Currency)]
        public string Regon { get; set; }
    }
}