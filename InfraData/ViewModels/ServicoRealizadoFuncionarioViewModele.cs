using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class ServicoRealizadoFuncionarioViewModel : ViewModelBase
    {
        [ScaffoldColumn(false)]
        public Guid ServicoRealizadoId { get; set; }
        [ScaffoldColumn(false)]
        public Guid FuncionarioId { get; set; }
        [ScaffoldColumn(false)]
        public decimal ComissaoRecebida { get; set; }
        [ScaffoldColumn(false)]
        public virtual Funcionario Funcionario { get; set; }
        [ScaffoldColumn(false)]
        public virtual ServicoRealizado ServicoRealizado { get; set; }
    }
}