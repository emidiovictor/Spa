using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class ClienteViewModel : ViewModelBase
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres ")]
        [MinLength(2, ErrorMessage = "Mínomo de 2 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 150 caracteres ")]
        [MinLength(2, ErrorMessage = "Mínomo de 2 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]

        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro;

        public virtual EnderecoViewModel EnderecoViewModel { get; set; }

    }
}