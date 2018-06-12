using Domain.Entity;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class AgendaViewModel : ViewModelBase
    {
      
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        public virtual List<ClienteViewModel> ClienteViewModel { get; set; }
        public virtual List<ServicoViewModel> ServicoViewModels { get; set; } 
        public virtual Funcionario Funcionario { get; set; }
        [ScaffoldColumn(false)]
        public Guid IdFuncionario { get; set; } //ONE TO MANY 
        [ScaffoldColumn(false)]
        public Guid IdCliente { get; set; }// ONE TO MANY
    }
}