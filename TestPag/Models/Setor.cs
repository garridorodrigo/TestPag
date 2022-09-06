using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestPag.Models
{
    public class Setor
    {
        [Key]
        public int SetorId { get; set; }
        public string Descricao { get; set; }
    }
}