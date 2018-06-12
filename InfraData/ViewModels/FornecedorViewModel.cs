using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class FornecedorViewModel : ViewModelBase
    {
        [Display(Name = "Razão Social")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [MinLength(2, ErrorMessage = "Mínimo de 2")]
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        [Display(Name = "Nome Fantasia")]
        [MaxLength(200, ErrorMessage = "Máximo de 200")]
        [MinLength(2, ErrorMessage = "Mínimo de 2")]
        public string NomeFantasia { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Invalido")]
        [MinLength(11, ErrorMessage = "Invalido")]
        public string CNPJ { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public virtual EnderecoViewModel EnderecoViewModel { get; set; }
    }
}