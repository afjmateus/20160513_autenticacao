using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _20160513_autenticacao.Models {
    public class Animais {

        // criar o construtor desta classe e carregar a lista de Consultas
        public Animais() {
            ListaDeConsultas = new HashSet<Consultas>();
        }

        [Key]
        public int AnimalID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Especie { get; set; }

        [Required]
        [StringLength(30)]
        public string Raca { get; set; }

        public float Peso { get; set; }

        // Preenchimento facultativo
        public float? Altura { get; set; }

        //**********************************
        // criar a chave forasteira
        // relaciona o objecto ANIMAL com um objecto DONO
        public Donos Dono { get; set; }

        // cria um atributo para funcionar como FK, na BD e relaciona-o com o atributo anterior
        [ForeignKey("Dono")]
        public int DonosFK { get; set; }
        //**********************************

        // especificar que um Animal tem muitas Consultas
        public ICollection<Consultas> ListaDeConsultas { get; set; }
    }
}