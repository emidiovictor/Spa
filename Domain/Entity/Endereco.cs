using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Salao Salao { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
