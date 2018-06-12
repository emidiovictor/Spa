using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ProdutoFornecedorConfig : EntityTypeConfiguration<ProdutoFornecedor>

    {
        public ProdutoFornecedorConfig()
        {
            HasKey(x =>
            new
            {
                x.FornecedorId,
                x.ProdutoId
            });

            HasRequired(x => x.Produto)
                .WithMany(x => x.ProdutoFornecedor)
                .HasForeignKey(x => x.ProdutoId);
#warning vir aqui
            //HasRequired(x => x.Fornecedor)
            //    .WithMany(x => x.ProdutoFornecedor)
            //    .HasForeignKey(x => x.FornecedorId);

            ToTable("Produto_Fornecedor");
        }
    }
}
