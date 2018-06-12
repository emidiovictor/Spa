using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Fornecedor : Entity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Endereco Endereco { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}

