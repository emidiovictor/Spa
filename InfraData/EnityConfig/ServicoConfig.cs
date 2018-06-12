using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            HasKey(x => x.Id);
          
            Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Valor)
                .IsRequired();


            #region Many to many!
            HasMany(f => f.Agenda)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("IdAgenda");
                    x.MapRightKey("IdServico");
                    x.ToTable("Agenda_Servico");
                });
            #endregion

            ToTable("Servicos");
        }
    }
}