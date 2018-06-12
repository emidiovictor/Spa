using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class ServicoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(150, ErrorMessage = "Máximo 150 cacteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor")]
        [Range(0.01, 100, ErrorMessage = "Valor deve ser maior que zero")]
        [DisplayName("Valor (R$)")]
        public double Valor { get; set; }
        [DisplayName("Necessário agendar")]
        public bool IsNecessarioAgendar { get; set; }

    }
}