using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public string CodBarras { get; set; }
        public double CustoMedio { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
