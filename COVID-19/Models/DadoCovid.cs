using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19.Models
{
    [Table("DadosCovid")]
    public class DadoCovid
    {
        [Key]
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Nº Mortes")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int mortes { get; set; }

        [Display(Name = "Nº Casos Confirmados")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int confirmados { get; set; }

        [Display(Name = "Nº Pessoas Recuperadas")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int recuperados { get; set; }

        [Display(Name = "País")]
        public int paisId { get; set; }

        [Display(Name = "País")]
        [ForeignKey("paisId")]
        public Pais pais { get; set; }

    }
}
