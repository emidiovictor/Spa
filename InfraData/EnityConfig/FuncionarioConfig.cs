using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Email)
                .IsRequired();

            Property(x => x.CPF)
                .IsFixedLength()
                .HasMaxLength(8);

            Property(x => x.DataAdmissao)
                .IsRequired();

            Property(x => x.DataNascimento)
                 .IsRequired();


            Property(x => x.Comissao)
                .IsRequired();

            Property(x => x.DataAdmissao)
                .IsRequired();



            //MANY TO MANY WITH EXTRA COLUMN
            HasMany(x => x.ServicoRealizadoFuncionario)
                .WithRequired()
                .HasForeignKey(x => x.ServicoRealizadoId);

            HasOptional(x => x.Endereco)
                .WithOptionalDependent(x => x.Funcionario)
              .Map(x => x.MapKey("EnderecoId"));

            ToTable("Funcionarios");
        }
    }
}