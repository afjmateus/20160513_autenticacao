using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _20160513_autenticacao.Models {
    public class Veterinarios {

        // criar o construtor desta classe e carregar a lista de Consultas
        public Veterinarios() {
            ListaDeConsultas = new HashSet<Consultas>();
        }

        [Key]
        public int VeterinarioID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Rua { get; set; }

        [Required]
        [StringLength(10)]
        public string NumPorta { get; set; }

        [StringLength(10)]
        public string Andar { get; set; }

        [Required]
        [StringLength(30)]
        public string CodPostal { get; set; }

        [Required]
        [StringLength(9)]
        public string NIF { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataEntradaClinica { get; set; }

        [Required]
        [StringLength(30)]
        public string NumCedulaProf { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataInscOrdem { get; set; }

        [Required]
        [StringLength(50)]
        public string Faculdade { get; set; }

        // especificar que um Animal tem muitas Consultas
        public ICollection<Consultas> ListaDeConsultas { get; set; }
    }
}