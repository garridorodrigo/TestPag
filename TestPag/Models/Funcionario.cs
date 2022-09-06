using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestPag.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeSocial { get; set; }
        public int RG { get; set; }
        public int CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public int CEP { get; set; }
        public string Complemento { get; set; }
        public string Estado { get; set; }
        public int TelefoneCelular { get; set; }
        public int TelefoneResidencial { get; set; }
        public Cargo Cargo { get; set; }
    }
}