using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _20160513_autenticacao.Models {
    public class Consultas {
        [Key]
        public int ConsultaID { get; set; }

        [Column(TypeName = "date")] // só recolhe datas, não horas
        public DateTime DataConsulta { get; set; }

        //**********************************
        // criar a chave forasteira
        // relaciona o objecto CONSULTA com um objecto ANIMAL
        public Animais Animal { get; set; }

        // cria um atributo para funcionar como FK, na BD e relaciona-o com o atributo anterior
        [ForeignKey("Animal")]
        public int AnimalFK { get; set; }

        // criar a chave forasteira
        // relaciona o objecto CONSULTA com um objecto VETERINARIO
        public Veterinarios Veterinario { get; set; }

        // cria um atributo para funcionar como FK, na BD e relaciona-o com o atributo anterior
        [ForeignKey("Veterinario")]
        public int VeterinarioFK { get; set; }
        //**********************************
    }
}