using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InfraData.ViewModels
{
    public class FuncionarioViewModel : ViewModelBase    {

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
        [ScaffoldColumnAttribute(false)]
        public DateTime DataCadastro;
        public bool Excluido { get; set; }
        [Required(ErrorMessage = "Comissao")]
        [Range(0.01, 100, ErrorMessage = "O valor deve ser maior quer zero")]
        [DisplayName("Comissao (R$)")]
        public decimal? Comissao { get; set; }
        [Display(Name = "Data Admissão")]
        [Required]
        public DateTime DataAdmissao { get; set; }
        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }
        public  EnderecoViewModel EnderecoViewModel { get; set; }


        [ScaffoldColumn(false)]
        public virtual ICollection<ServicoRealizadoFuncionario> ServicoRealizadoFuncionario { get; set; }
    }
}