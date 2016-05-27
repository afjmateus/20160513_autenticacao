using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _20160513_autenticacao.Models {
    public class Donos {
        // vai representar os dados das tabelas dos DONOS

        // criar o construtor desta classe e carregar a lista de Animais
        public Donos() {
            ListaDeAnimais = new HashSet<Animais>();
        }


        [Key]
        public int DonoID { get; set; }

        [Required]
        public string Nome { set; get; }

        [Required]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }
    }
}