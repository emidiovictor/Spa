using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class ServicoRealizado : Entity
    {

        public Guid ServicoId { get; set; }  // N TO N
        public Guid ClienteId { get; set; } // 1 servico para 1 cliente
        public DateTime DataServico { get; set; }

        public decimal Valor { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Desconto { get; set; }
        public decimal TotalComDesconto { get; set; }
        public double TotalSemDesconto { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<ServicoRealizadoFuncionario> ServicoRealizadoFuncionario{ get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}