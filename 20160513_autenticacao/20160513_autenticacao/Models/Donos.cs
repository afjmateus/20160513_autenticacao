using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _20160513_autenticacao.Models {
    public class Donos {
        // vai representar os dados das tabelas dos DONOS

        [Key]
        public int DonosID { get; set; }

        public string Nome { get; set; }

        public string NIF { get; set; }

    }
}