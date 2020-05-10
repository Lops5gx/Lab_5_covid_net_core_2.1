using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19.Models
{
    [Table("Dados")]
    

    public class DadoCovid
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Casos")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        private int casos { get; set; }

        [Display(Name = "Mortes")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        private int mortes { get; set; }

        [Display(Name = "Recuperados")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        private int recuperados { get; set; }

        private String pais { get; set; }

        public int PaisesId { get; set; }

        [ForeignKey("PaisesId")]
        public Pais Paises { get; set; }


        //public void adicionaCasos(int qtd)
        //{
        //    casos += qtd;
        //}
        //public void removerCasos(int qtd)
        //{
        //    casos = casos - qtd;
        //}

        //public void atualizaCasos(int numCasos)
        //{
        //    casos = numCasos;
        //}





        //public void adicionaMortes(int qtd)
        //{
        //    mortes += qtd;
        //}

        //public void removerMortes(int qtd)
        //{
        //    mortes = mortes - qtd;
        //}

        //public void atualizaMortes(int numMortes)
        //{
        //    casos = numMortes;
        //}





        public void adicionaRecuperados(int qtd)
        {
            recuperados += qtd;
        }

        public void removerRecuperados(int qtd)
        {
            recuperados = recuperados - qtd;
        }

        public void atualizaRecuperados(int numRecuperados)
        {
            casos = numRecuperados;
        }


    }
}
