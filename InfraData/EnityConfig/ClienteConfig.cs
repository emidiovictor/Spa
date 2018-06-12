
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Clientes>
    {

        public ClienteConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.CPF)
                .IsFixedLength()
                .HasMaxLength(11);

            HasOptional(x => x.Endereco)
                .WithOptionalDependent(x => x.Cliente)
                .Map(x => x.MapKey("EnderecoId"));
        }
    }
}