using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class SalaoConfig : EntityTypeConfiguration<Salao>
    {

        public SalaoConfig()
        {
            Property(x => x.RazaoSocial)
                .IsRequired()
                .HasMaxLength(200);
            Property(x => x.NomeFantasia)
                .IsRequired().
                HasMaxLength(200);
            Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(11);

            HasOptional(x => x.Endereco)
                .WithOptionalDependent(x => x.Salao)
        .Map(x => x.MapKey("EnderecoId"));

            ToTable("Saloes");
        }
    }
}