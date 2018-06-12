using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Servico : Entity
    {
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public bool? IsNecessarioAgendar { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
        public virtual ICollection<ServicoRealizado> ServicoRealizadoCliente { get; set; }
        public override bool IsValid()

        {
            return true;

        }
    }
}