using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19.Models
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        [Display(Name = "Código")]
        public int idPais { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string nomePais { get; set; }
    }
}
