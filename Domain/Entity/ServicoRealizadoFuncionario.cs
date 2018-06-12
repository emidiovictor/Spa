using System;

namespace Domain.Entity
{
    public class ServicoRealizadoFuncionario : Entity
    {
        public Guid ServicoRealizadoId { get; set; }
        public Guid FuncionarioId { get; set; }
        public decimal ComissaoRecebida { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual ServicoRealizado ServicoRealizado { get; set; }

        public override bool IsValid()
        {
            return true;

        }
    }
}