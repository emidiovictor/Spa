using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {

        public FornecedorConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.NomeFantasia)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.CNPJ)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            HasOptional(x => x.Endereco)
                .WithOptionalDependent(x => x.Fornecedor)
             .Map(x => x.MapKey("EnderecoId"));
            ToTable("Fornecedores");
        }
    }
}
