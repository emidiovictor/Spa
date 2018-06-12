using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Funcionario : Entity
    {
        public Funcionario()
        {
            Endereco = new Endereco();
        }
        public string Nome { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Excluido { get; set; }
        public decimal? Comissao { get; set; }
        public DateTime DataAdmissao { get; set; }
        public bool IsAtivo { get; set; }

        public string  Especialidade { get; set; }
        public virtual Endereco Endereco { get; set; }


        public virtual ICollection<ServicoRealizadoFuncionario> ServicoRealizadoFuncionario  { get; set; }
        public override bool IsValid()
        {
            return true;
        }

    }
}

