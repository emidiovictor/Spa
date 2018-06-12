using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.CodBarras)
                .HasMaxLength(255)
                .IsOptional();

            Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            ToTable("Produtos");

        }
    }
}