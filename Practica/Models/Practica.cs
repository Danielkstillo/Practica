using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.Models
{
    public class Practica
    {
        [Key]
        private static readonly string[] Summaries = new[]
        {
            "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
        };

        [Required(ErrorMessage ="Requerido")]
        [Display(Name ="trebol, espada, diamante, unicornio")]
        public string Nombre { get; set; }

        [Url]
        [StringLength(maximumLength:200,MinimumLength =2)]

        public string Enlace { get; set; }

    }
}
