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

    }
}