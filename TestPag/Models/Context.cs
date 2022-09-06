using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestPag.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=ContextConnectionString") {
            Database.SetInitializer<Context>(new ContextDBInitializer());
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Setor> Setor { get; set; }
    }
}