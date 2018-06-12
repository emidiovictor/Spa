using Domain.Entity;

using System.Data.Entity.ModelConfiguration;

namespace InfraData.EnityConfig
{
    public class AgendaConfig : EntityTypeConfiguration<Agenda>
    {
        public AgendaConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Data)
                .IsRequired();


            #warning vir aqui
            ///// ONE TO MANY!!!!
            //HasRequired(x => x.Cliente)
            //    .WithMany(x => x.Agendas)
            //    .HasForeignKey(x => x.IdCliente);


            //HasRequired(x => x.Funcionario)
            //    .WithMany(x => x.Agendas)
            //    .HasForeignKey(x => x.IdFuncionario);
            //#endregion




            ToTable("Agenda");

        }
    }
}
