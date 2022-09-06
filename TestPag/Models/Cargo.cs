using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestPag.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        public string Descricao { get; set; }
        public double Salario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEncerramento { get; set; }
        public Setor Setor { get; set; }
    }
}