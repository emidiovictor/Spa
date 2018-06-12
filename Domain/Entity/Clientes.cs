using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Clientes : Entity
    {


        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Endereco Endereco { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
