using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ServicoRealizadoConfig : EntityTypeConfiguration<ServicoRealizado>
    {

        public ServicoRealizadoConfig()
        {
            HasKey(x => x.Id);

#warning vir aqui
            //// 0..1 TO MANY --CLIENTE
            //HasRequired(x => x.Cliente)
            //    .WithMany(x => x.ServicosRealizadoCliente)
            //    .HasForeignKey(x=> x.ClienteId);

            //Many to Many
            HasMany(x => x.Servicos)
                .WithMany(x => x.ServicoRealizadoCliente)
                .Map(x =>
                {
                    x.MapLeftKey("Id_Servico");
                    x.MapRightKey("Id_ServicoRealizado");
                    x.ToTable("ServicoRealizoServico");
                });

            HasMany(x => x.ServicoRealizadoFuncionario)
                .WithRequired()
                .HasForeignKey(x => x.FuncionarioId);

            ToTable("Servico_Realizado_Cliente");

        }
    }
}
