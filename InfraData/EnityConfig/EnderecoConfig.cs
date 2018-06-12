using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {

        public EnderecoConfig()
        {
            Property(x => x.Bairro)
                .IsRequired();

            Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(x => x.Cidade)
                .IsRequired();

            Property(x => x.Complemento)
                .HasMaxLength(100);

          

            ToTable("Enderecos");
        }


    

    }
}