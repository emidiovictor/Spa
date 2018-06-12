using System;

namespace Domain.Entity
{
    public class ProdutoFornecedor : Entity
    {
        public Guid ProdutoId { get; set; }
        public Guid FornecedorId { get; set; }
        public decimal Custo { get; set; }
        //nav
        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}