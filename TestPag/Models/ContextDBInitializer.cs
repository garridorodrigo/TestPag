using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestPag.Models
{
    public class ContextDBInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {

            IList<Setor> setorList = new List<Setor>();
            setorList.Add(new Setor { Descricao = "RH" });
            setorList.Add(new Setor { Descricao = "TI" });
            setorList.Add(new Setor { Descricao = "Contabilidade" });
            setorList.Add(new Setor { Descricao = "Administração" });

            base.Seed(context);
        }


    }
}