

using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace InfraData.EnityConfig
{
    public class ServicoRealizadoFuncionarioConfing : EntityTypeConfiguration<ServicoRealizadoFuncionario>
    {
        public ServicoRealizadoFuncionarioConfing()
        {
               HasKey (x =>
               new
               {
                   x.FuncionarioId,
                   x.ServicoRealizadoId
               });

        }
    }
}