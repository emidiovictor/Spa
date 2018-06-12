using Domain.Entity;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraData.ViewModels
{
    public class ProdutoFornecedorViewModel : ViewModelBase
    {
        [ScaffoldColumn(false)]
        public decimal Custo { get; set; }
        [ScaffoldColumn(false)]
        public Produto Produto { get; set; }
        [ScaffoldColumn(false)]
        public Fornecedor Fornecedor { get; set; }
        [ScaffoldColumn(false)]
        public Guid ProdutoId { get; set; }
        public Guid FornecedorId { get; set; }

    }
}