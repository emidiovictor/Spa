using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Repositories
{
    public class ServicoRepository : Repository<Servico> , IServicoRepository
    {
        public ServicoRepository(Context context) : base(context)
        {

        }
    }
}
