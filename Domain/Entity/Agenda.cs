using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Agenda : Entity
    {
        public Guid IdFuncionario { get; set; } //ONE TO MANY 
        public Guid IdCliente { get; set; }// ONE TO MANY
        public DateTime Data { get; set; }
        //
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<Servico> ServicoList { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        //
        public override bool IsValid()
        {
            return true;

        }
    }
}
