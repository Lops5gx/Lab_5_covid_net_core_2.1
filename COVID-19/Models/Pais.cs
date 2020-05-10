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
        public int id{ get; set; }

        [Display(Name = "Paises")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        private ArraySegment<String> Nome { get; set; }


        public ICollection<DadoCovid> DadosCovid{ get; set; }

        Pais()
        {
            Nome.Append("Alemanha");
            Nome.Append("Brasil");
            Nome.Append("China");
            Nome.Append("Estados Unidos");
            Nome.Append("Itália");
        }



    }
}
