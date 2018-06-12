using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Código de Barras")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string CodBarras { get; set; }

        [Required(ErrorMessage = "Custo Médio")]
        [Range(0.01, 99999999, ErrorMessage = "Valor maior que 0.01")]
        [DisplayName("Custo Médio (R$)")]
        public double CustoMedio { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}